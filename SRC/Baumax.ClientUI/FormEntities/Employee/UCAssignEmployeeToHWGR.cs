using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Baumax.Contract.Exceptions.EntityExceptions;
using Baumax.Domain;
using Baumax.Environment;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Baumax.ClientUI.FormEntities.Employee
{
    public partial class UCAssignEmployeeToHWGR : UCBaseEntity 
    {
        
        public Domain.Employee Employee
        {
            get { return (Domain.Employee)Entity; }
        }

        public UCAssignEmployeeToHWGR()
        {
            InitializeComponent();
            
            if (ClientEnvironment.IsRuntimeMode)
                InitRepositoryItems();
        }

        private void InitRepositoryItems()
        {
            List<HWGR> hwgrs = ClientEnvironment.HWGRService.FindAll();
            //HWGR nullHwgr = new HWGR(0, 0, GetLocalized("Empty"));
            hwgrs.Insert(0, new HWGR(0, 0, GetLocalized("Empty")));
            HwgrLookUpCtrl.EntityList = hwgrs;
        }

        #region Form properties

        public long Hwgr
        {
            get { return HwgrLookUpCtrl.CurrentId; }
            set { HwgrLookUpCtrl.CurrentId = value; }
        }

        #endregion

        protected override void EntityChanged()
        {
            Bind();
            base.EntityChanged();
        }

        public override void Bind()
        {
            if (Employee != null)
            {
                teEmployeeName.Text = Employee.FullName;
                HwgrLookUpCtrl.CurrentId = Employee.OrderHwgrID == null ? 0 : Employee.OrderHwgrID.Value;
            }
            base.Bind();
        }

        public bool IsModified()
        {
            return true;
            /*if (Context.CurrentRelation.IsNew) return true;

            EmployeeRelation rel = Context.CurrentRelation;

            return (rel.BeginTime != BeginTime ||
                    rel.EndTime == EndTime ||
                    rel.WorldID == StoreWorldId); */
        }

        public override bool Commit()
        {
            if (IsValid())
            {
                if (IsModified())
                {
                    try
                    {
                        Employee.OrderHwgrID = HwgrLookUpCtrl.CurrentId == 0 ? (long?)null : HwgrLookUpCtrl.CurrentId;
                        ClientEnvironment.EmployeeService.AssignHwgr(Employee.ID, Employee.OrderHwgrID);
                    }
                    catch (ValidationException ex)
                    {
                    	string localizedMessage = GetLocalized(ex.Message);
                        ErrorMessage(localizedMessage);

                        return false;
                    }
                    catch (EntityException ex)
                    {
                        ProcessEntityException(ex);
                        return false;
                    }
                    Modified = true;
                }
                else 
                    Modified = false;

            }
            else 
                return false;

            return base.Commit();
        }

        private void HwgrLookUpCtrl_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                HwgrLookUpCtrl.CurrentId = 0;
            }
        }
    }
}
