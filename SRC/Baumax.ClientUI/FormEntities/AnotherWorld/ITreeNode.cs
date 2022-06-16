using System;
using System.Collections.Generic;
using System.Text;

namespace Baumax.ClientUI.FormEntities.AnotherWorld
{
    public interface ITreeNode
    {
        int ParentID {get;set;}
        int ID {get;set;}
        int ImageIndex { get;set;}

        long RealID { get;set;}
        string Name {get;set;}
        DateTime BeginTime {get;set;}
        DateTime EndTime {get;set;}
    }
}
