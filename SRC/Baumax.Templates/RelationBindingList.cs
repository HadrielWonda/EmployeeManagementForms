using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Baumax.Templates
{
    public class RelationBindingList<T> : BindingTemplate<T>
        where T : class
    {
        private List<T> _NewItems = new List<T>();
        
        public RelationBindingList(IList<T> lst) : base(lst) { }
        public RelationBindingList(List<T> lst) : base(lst) { }

        public RelationBindingList(IList lst) 
        {
            CopyList(lst);
        }

        public RelationBindingList() : base() { }
        
        public new void Add(T item)
        {
            base.Add(item);
            _NewItems.Add(item);
        }
        
        protected override void RemoveItem(int index)
        {
            T item = this[index];
            _NewItems.Remove(item);
            base.RemoveItem(index);
        }

        public new List<T> GetNewItemList()
        {
            return _NewItems;
        }
    }
}
