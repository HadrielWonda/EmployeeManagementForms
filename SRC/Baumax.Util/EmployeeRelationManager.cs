using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Dao;
using Baumax.Domain;
using Baumax.Contract.Interfaces;
using Baumax.Contract.TimePlanning;

namespace Baumax.Util
{
	public sealed class EmployeeRelationManager
	{
		private readonly IEmployeeRelationDao _employeeRelationsDao = null;
		private readonly IEmployeeDao _employeeDao = null;
		private readonly Employee _employee;
        private readonly IEmployeeContractService _contractservice = null;
		private List<_EmployeeRelation> _commonList = null;
		private readonly EmployeeRelationComparer _comparer = new EmployeeRelationComparer();

		public EmployeeRelationManager(Employee employee, IEmployeeRelationDao employeeRelationDao, IEmployeeDao employeeDao, IEmployeeContractService contractservice)
		{
			if (employeeRelationDao == null)
			{
				throw new ArgumentNullException("employeeRelationDao");
			}
			_employeeRelationsDao = employeeRelationDao;
			if (employeeDao == null)
			{
				throw new ArgumentNullException("employeeDao");
			}
			_employeeDao = employeeDao;
			if (employee == null)
			{
				throw new ArgumentNullException("employee");
			}

            _contractservice = contractservice;
            if (_contractservice == null)
            {
                throw new ArgumentNullException("EmployeeContractService");
            }

			_employee = employee;
			//
			LoadRelations();
		}

		public long EmployeeID
		{
			get { return _employee.ID; }
		}

		public long MainStoreID
		{
			get { return _employee.MainStoreID; }
		}

		private IEmployeeRelationDao Dao
		{
			get { return _employeeRelationsDao; }
		}

		private void LoadRelations()
		{
			IList lst = Dao.GetEmployeeRelations(EmployeeID);

			if(lst != null)
			{
				_commonList = new List<_EmployeeRelation>();
				foreach(EmployeeRelation rel in lst)
				{
					_commonList.Add(new _EmployeeRelation(rel));
				}

				_commonList.Sort(_comparer);
			}
		}

		

		public bool CanDeleteRelations (DateTime startDate, DateTime endDate)
		{
			return !_employeeDao.HasWorkingOrAbsenceTime(_employee.ID, startDate, endDate);
		}

		public void DeleteForPeriod (DateTime startDate, DateTime endDate)
		{
			if (CanDeleteRelations(startDate, endDate))
			{
				List<_EmployeeRelation> relationsToDelete = _commonList.FindAll(delegate (_EmployeeRelation relation)
				                                                                {
				                                                                	return relation.IsIntersectPeriod(startDate, endDate);
				                                                                });
				foreach (_EmployeeRelation relation in relationsToDelete)
				{
					if (relation.BeginTime >= startDate && relation.EndTime <= endDate)
					{
						relation.Deleted = true;
					} else
					{
						relation.TrimTo(startDate, endDate);
					}
				}
			}
		}

		internal bool IsMainStoreRelation(_EmployeeRelation relation)
		{
			if(relation == null)
			{
				throw new ArgumentNullException("relation");
			}
			return MainStoreID == relation.StoreID;
		}

		public void InsertDeligationToStore(EmployeeRelation newDeligation)
		{
            DoValidate(newDeligation);

			_EmployeeRelation newRelation = new _EmployeeRelation(newDeligation);

			List<_EmployeeRelation> intersectedRelations = _commonList.FindAll(delegate(_EmployeeRelation relation)
			                                                                   {
			                                                                   	if(relation.IsIntersectRelation(newRelation))
			                                                                   	{
			                                                                   		if(!IsMainStoreRelation(relation) && !relation.IsEqualByStore(newRelation))
			                                                                   		{
																						throw new ValidationException("ErrorAssignToWorldDateRangeIntersect", null);
			                                                                   		}
			                                                                   		return true;
			                                                                   	}
			                                                                   	return false;
			                                                                   });
			intersectedRelations.Sort(_comparer);

			InsertRelation2(newRelation, intersectedRelations);
		}

        private void DoValidate(EmployeeRelation newEmployeeRelation)
        {
            // Validation: EmployeeRelation should be withing Employee's contract time.

            ListEmployeeContracts contracts = new ListEmployeeContracts(_contractservice, _employee.ID);
            UnbreakContract validator = contracts.GetUnbreakContracts();

            if (!validator.CheckRelation(newEmployeeRelation))
                throw new ValidationException("ErrorRelationOutsideContractTime", null);

            //if (newEmployeeRelation.BeginTime < _employee.ContractBegin || newEmployeeRelation.EndTime > _employee.ContractEnd)
            //{
            //    throw new ValidationException("ErrorRelationOutsideContractTime", null);
            //}
            // Validation: Is Time planning is already defined within time range of new relation, ValidationExceptin is thrown
            if (_employeeDao.HasWorkingOrAbsenceTime(_employee.ID, newEmployeeRelation.BeginTime, newEmployeeRelation.EndTime))
            {
                throw new ValidationException("ErrorTimePlanningAlreadyDefined", null);
            }

        }

        /// <summary>
        /// Updates the current world assignment. BeginDate and EndDate should be EXACTLY THE SAME as of existing relation.
        /// </summary>
        /// <param name="newEmployeeRelation">The new employee relation.</param>
        /// acpro #122269
        public void UpdateAssignment(EmployeeRelation newEmployeeRelation)
        {
            DoValidate(newEmployeeRelation);

            _EmployeeRelation newRelation = new _EmployeeRelation(newEmployeeRelation);

            List<_EmployeeRelation> intersectedRelations = _commonList.FindAll(delegate(_EmployeeRelation relation)
                                                                               {
                                                                                   if (relation.IsIntersectRelation(newRelation) || (relation.IsEqualByData(newRelation) && relation.IsNeighborRelation(newRelation)))
                                                                                   {
                                                                                       if (!relation.IsEqualByStore(newRelation) && !IsMainStoreRelation(newRelation))
                                                                                       {
                                                                                           throw new ValidationException("ErrorAssignToWorldDateRangeIntersect", null);
                                                                                       }
                                                                                       return true;
                                                                                   }
                                                                                   return false;
                                                                               });
            //Debug.Assert(intersectedRelations.Count == 1);
            //Debug.Assert(intersectedRelations[0].BeginTime == newEmployeeRelation.BeginTime);
            //Debug.Assert(intersectedRelations[0].EndTime == newEmployeeRelation.EndTime);
            intersectedRelations[0].StoreID = newRelation.StoreID;
            intersectedRelations[0].WorldID = newRelation.WorldID;
            intersectedRelations[0].HWGR_ID = newRelation.HWGR_ID;
        }

		public void InsertWorldAssignment(EmployeeRelation newEmployeeRelation)
		{
            DoValidate(newEmployeeRelation);

			_EmployeeRelation newRelation = new _EmployeeRelation(newEmployeeRelation);

			List<_EmployeeRelation> intersectedRelations = _commonList.FindAll(delegate(_EmployeeRelation relation)
			                                                                   {
			                                                                   	if(relation.IsIntersectRelation(newRelation) || (relation.IsEqualByData(newRelation) && relation.IsNeighborRelation(newRelation)))
			                                                                   	{
			                                                                   		if(!relation.IsEqualByStore(newRelation) && !IsMainStoreRelation(newRelation)) 
			                                                                   		{
																						throw new ValidationException("ErrorAssignToWorldDateRangeIntersect", null);
			                                                                   		}
			                                                                   		return true;
			                                                                   	}
			                                                                   	return false;
			                                                                   });
			intersectedRelations.Sort(_comparer);

			InsertRelation2(newRelation, intersectedRelations);
		}

		private void InsertRelation2(_EmployeeRelation newRelation, List<_EmployeeRelation> intersections)
		{
			int intersectionIndex = 0;

			foreach(_EmployeeRelation intersection in intersections)
			{
				intersectionIndex = _commonList.IndexOf(intersection);

				if(intersection.Covers(newRelation))
				{
					if(intersection.IsEqualByData(newRelation))
					{
						newRelation.Deleted = true;
					} else
					{
						_EmployeeRelation leadingInsert = intersection.Split(newRelation);
						if(intersection.IsValid(true))
						{
							_commonList.Insert(intersectionIndex, newRelation);
						}
						if(leadingInsert != null && leadingInsert.IsValid(true))
						{
							_commonList.Insert(intersectionIndex, leadingInsert);
						}
					}
				} else if(newRelation.Covers(intersection))
				{
					intersection.Deleted = true;
				} else
				{
					if(intersection.IsEqualByData(newRelation))
					{
						intersection.Merge(newRelation);
						newRelation.Deleted = true;
						newRelation = intersection;
					} else if(intersection.IsIntersectRelation(newRelation))
					{
						intersection.TrimTo(newRelation);
						intersection.IsValid(true);
					}
				}
			}
			if(!_commonList.Contains(newRelation) && !newRelation.Deleted && newRelation.IsValid(true))
			{
				_commonList.Insert(intersectionIndex, newRelation);
			}
		}

		public void Commit()
		{

			foreach (_EmployeeRelation r in _commonList)
			{
				if (r.Deleted && !r.IsNew)
				{
					Dao.DeleteByID(r.ID);
				}
				else if (r.Modified && !r.IsNew)
				{
					Dao.SaveOrUpdate(r.Entity);
				}
				else if (r.IsNew)
				{
					Dao.Save(r.Entity);
				}
			}
		}
	}

	internal class _EmployeeRelation : BaseEntity
	{
		private readonly EmployeeRelation m_owner = null;
		private bool m_deleted = false;
		private bool m_modified = false;

		public _EmployeeRelation(EmployeeRelation rel)
		{
			m_owner = rel;
			_ID = rel.ID;
		}

		public EmployeeRelation Entity
		{
			get { return m_owner; }
		}

		public bool Deleted
		{
			get { return m_deleted; }
			set { m_deleted = value; }
		}

		public bool Modified
		{
			get { return m_modified; }
			set { m_modified = value; }
		}

		public DateTime BeginTime
		{
			get { return m_owner.BeginTime; }
			set
			{
				if(value != BeginTime)
				{
					m_owner.BeginTime = value;
					Modified = true;
				}
			}
		}

		public DateTime EndTime
		{
			get { return m_owner.EndTime; }
			set
			{
				if(value != EndTime)
				{
					m_owner.EndTime = value;
					Modified = true;
				}
			}
		}

		public long? HWGR_ID
		{
			get { return m_owner.HWGR_ID; }
			set { m_owner.HWGR_ID = value; }
		}

		public long StoreID
		{
			get { return m_owner.StoreID; }
			set { m_owner.StoreID = value; }
		}

		public long EmployeeID
		{
			get { return m_owner.EmployeeID; }
			set { m_owner.EmployeeID = value; }
		}

		public long? WorldID
		{
			get { return m_owner.WorldID; }
			set { m_owner.WorldID = value; }
		}

		public _EmployeeRelation Split(_EmployeeRelation relation)
		{
			if(Covers(relation))
			{
				_EmployeeRelation headPart = new _EmployeeRelation(CreateCopy());
				BeginTime = relation.EndTime.Date.AddDays(1);
				IsValid(true);
				headPart.EndTime = relation.BeginTime.AddDays(-1);

				return headPart;
			}
			return null;
		}

		/// <summary>
		/// Merge 2 relation ranges; REMARK: The method will modify the new range, so that a new relation will start next day after This
		/// </summary>
		/// <param name="rel">Relation to be merged</param>
		/// <returns>Boolean result means whether <paramref name="rel"/> should be inserted to relations list</returns>
		public bool Merge(_EmployeeRelation rel)
		{
			if(IsEqualByData(rel) && CanMerge(rel))
			{
				if(BeginTime > rel.BeginTime)
				{
					BeginTime = rel.BeginTime;
				}
				if(EndTime < rel.EndTime)
				{
					EndTime = rel.EndTime;
				}
				return true;
			} else
			{
				return false;
			}
		}

		public void TrimTo(DateTime beginTime, DateTime endTime)
		{
			if (BeginTime >= beginTime && EndTime > endTime)
			{
				BeginTime = endTime.AddDays(1);
			}
			if (EndTime <= endTime && BeginTime < beginTime)
			{
				EndTime = beginTime.AddDays(-1);
			}
		}

		public void TrimTo(_EmployeeRelation relation)
		{
			if(BeginTime > relation.BeginTime)
			{
				BeginTime = relation.EndTime.AddDays(1);
			}
			if(EndTime < relation.EndTime)
			{
				EndTime = relation.BeginTime.AddDays(-1);
			}
		}

		public _EmployeeRelation CopyToRange(_EmployeeRelation datesHolder)
		{
			_EmployeeRelation result = new _EmployeeRelation(CreateCopy());
			result.BeginTime = datesHolder.BeginTime;
			result.EndTime = datesHolder.EndTime;

			return result;
		}

		private EmployeeRelation CreateCopy()
		{
			EmployeeRelation newrelation = new EmployeeRelation();
			CopyTo(m_owner, newrelation);
			newrelation.ID = 0;
			return newrelation;
		}

		public bool IsHeadIntersection(_EmployeeRelation relation)
		{
			return BeginTime >= relation.BeginTime && BeginTime < relation.EndTime;
		}

		public bool IsTailIntersection(_EmployeeRelation relation)
		{
			return EndTime > relation.BeginTime && EndTime <= relation.EndTime;
		}

		public bool Covers(_EmployeeRelation rel)
		{
			return (BeginTime <= rel.BeginTime && EndTime >= rel.EndTime);
		}

		public bool IsIntersectPeriod (DateTime beginTime, DateTime endTime)
		{
			return !((EndTime < beginTime) || (endTime < BeginTime));
		}

		public bool IsIntersectRelation(_EmployeeRelation newitem)
		{
			return !((EndTime < newitem.BeginTime) || (newitem.EndTime < BeginTime));
		}

		public bool IsNeighborRelation(_EmployeeRelation relation)
		{
			return (EndTime.AddDays(1) == relation.BeginTime || relation.EndTime == BeginTime.AddDays(-1));
		}

		public bool IsIntersectOrNeighborRelation(_EmployeeRelation relation)
		{
			return IsIntersectRelation(relation) || IsNeighborRelation(relation);
		}

		public bool IsEqualByData(_EmployeeRelation rel)
		{
			return EmployeeID == rel.EmployeeID && StoreID == rel.StoreID && WorldID == rel.WorldID;
		}

		public bool IsEqualByStore(_EmployeeRelation relation)
		{
			return EmployeeID == relation.EmployeeID && StoreID == relation.StoreID;
		}

		public bool CanMerge(_EmployeeRelation rel)
		{
			return ((BeginTime >= rel.BeginTime && EndTime >= rel.EndTime) || (BeginTime <= rel.BeginTime && EndTime <= rel.EndTime));
		}

		/// <summary>
		/// Check whether instance is valid: BeginTime &lt; EndTime
		/// </summary>
		/// <param name="bDeleted">Mark checked instance as Deleted, if it is not valid</param>
		/// <returns></returns>
		public bool IsValid(bool bDeleted)
		{
			if(BeginTime > EndTime)
			{
				if(bDeleted)
				{
					Deleted = true;
				}
				return false;
			}
			return !Deleted;
		}
	}

	internal class EmployeeRelationComparer : IComparer<_EmployeeRelation>
	{
		#region IComparer<_EmployeeRelation> Members

		public int Compare(_EmployeeRelation a, _EmployeeRelation b)
		{
			if(a.Deleted && b.Deleted)
			{
				return a.ID.CompareTo(b.ID);
			}

			if(a.Deleted)
			{
				return -1;
			}
			if(b.Deleted)
			{
				return 1;
			}

			if(a.BeginTime == b.BeginTime && a.EndTime == b.EndTime)
			{
				return 1;
			}

			if(a.EndTime < b.BeginTime)
			{
				return -1;
			}

			return 1;
		}

		#endregion
	}
}