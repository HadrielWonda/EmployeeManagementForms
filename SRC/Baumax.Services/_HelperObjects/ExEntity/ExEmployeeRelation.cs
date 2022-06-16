using System;
using System.Collections.Generic;
using System.Text;
using Baumax.Domain;
using Baumax.AppServer.Environment;

namespace Baumax.Services._HelperObjects.ExEntity
{

    public partial class ExEmployeeRelation
    {
        long _employeeid = 0;

        public long EmployeeId
        {
            get { return _employeeid; }
        }
        public ExEmployeeRelation(long emplid)
        {
            _employeeid = emplid;
        }
        List<EmployeeRelation> _relations = null;

        public void SynchronizeToContract(DateTime date)
        {
            _relations = ExEmployeeRelation.List(EmployeeId);
            if (_relations == null) return;

            EmployeeRelation entity = _relations[_relations.Count - 1];

            if (entity.EndTime < date)
            {
                entity.EndTime = date;
                ExEmployeeRelation.Update(entity);
            }
            else
            {
                foreach (EmployeeRelation next_entity in _relations)
                {
                    if (next_entity.IsContainDate(date))
                    {
                        next_entity.EndTime = date;
                        ExEmployeeRelation.Update(next_entity);
                    }
                    else if (next_entity.BeginTime > date)
                    {
                        ExEmployeeRelation.Delete(next_entity);
                    }
                }
            }

            _relations = null;
        }
    }

    public partial class ExEmployeeRelation
    {
        public static List<EmployeeRelation> List(long id)
        {
            List<EmployeeRelation> list = ServerEnvironment.EmployeeRelationService.GetEmployeeRelations(id);
            return list;
            
        }

        public static void Update(EmployeeRelation relation)
        {
            ServerEnvironment.EmployeeRelationService.Update(relation);
        }

        public static void Delete(EmployeeRelation relation)
        {
            ServerEnvironment.EmployeeRelationService.Delete (relation);
        }

    }
}
