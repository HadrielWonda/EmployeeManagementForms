using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Text;
using Baumax.Domain;

namespace Baumax.Templates
{

    public class BindingTemplate<T> : BindingList<T> where T : class
    {
        List<T> _removedItems = new List<T>();

        public BindingTemplate(IList<T> lst) : base(lst) { }
        public BindingTemplate(List<T> lst) : base(lst) { }

        public BindingTemplate(IList lst) 
        {
            CopyList(lst);
        }

        public BindingTemplate() : base() { }

        public virtual void CopyList(IList lst)
        {
            if (lst != null)
            {
                foreach (BaseEntity entity in lst)
                {
                    this.Add((entity as T));
                }
            }
        }

        public virtual void CopyList(IList<T> lst)
        {
            if (lst != null)
            {
                foreach (T entity in lst)
                {
                    this.Add(entity);
                }
            }
        }

        public virtual void CopyList(List<T> lst)
        {
            if (lst != null)
            {
                foreach (T entity in lst)
                {
                    this.Add(entity);
                }
            }
        }

        protected override void RemoveItem(int index)
        {
            T removedItem = this[index];

            base.RemoveItem(index);

            BaseEntity baseEntity = (removedItem as BaseEntity);
            if (baseEntity != null)
            {
                if (!baseEntity.IsNew)
                {
                    _removedItems.Add(removedItem);
                }

            }
            else throw new InvalidCastException();
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            ClearRemoveList();
        }

        public T GetItemByID(long id)
        {
            BaseEntity entity = null;
            foreach (T nextItem in this)
            {
                entity = (nextItem as BaseEntity);
                if (entity.ID == id) return nextItem;
            }
            return null;
        }

        public List<T> GetRemoveList()
        {
            List<T> removed = new List<T>(_removedItems);

            return removed;
        }

        public List<T> GetNewItemList()
        {
            List<T> newList = new List<T>();
            BaseEntity entity = null;
            foreach (T nextItem in this)
            {
                entity = (nextItem as BaseEntity);
                if (entity.IsNew) 
                    newList.Add(nextItem);
            }
            return newList;
        }

        public void ClearRemoveList()
        {
            _removedItems.Clear();
        }

        public void RestoreItems()
        {
            foreach (T nextItem in _removedItems)
                this.Add(nextItem);

            ClearRemoveList();
        }

        public int GetIndexOfEntity(long id)
        {
            BaseEntity entity = null;
            for (int i = 0; i < this.Count; i++)
            {
                entity = (this[i] as BaseEntity);
                if (entity != null && entity.ID == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public void ResetItemById(long id)
        {
            int idx = GetIndexOfEntity(id);

            if (idx >= 0)
            {
                ResetItem(idx);
            }
        }
        public void RemoveEntityById(long id)
        {
            int idx = GetIndexOfEntity(id);
            if (idx != -1) this.RemoveAt(idx);
        }
        public void SetEntity(BaseEntity aEntity)
        {
            int idx = GetIndexOfEntity(aEntity.ID);

            if (idx >= 0)
            {
                BaseEntity entity = (this[idx] as BaseEntity);
                if (!object.ReferenceEquals(entity, aEntity))
                    this[idx] = (aEntity as T);
                ResetItem(idx);
            }
        }

        public long[] GetIds()
        {
            long[] ids = new long[this.Count];
            BaseEntity entity = null;
            for (int i = 0; i < this.Count; i++)
            {
                entity = (this[i] as BaseEntity);
                ids[i] = entity.ID;
            }
            return ids;
        }

    }
}
