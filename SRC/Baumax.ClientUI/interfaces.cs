namespace Baumax.ClientUI
{
    public interface IEditableEntityCtrl
    {
        void Bind();
        bool IsValid();
        bool Modified { get; set;}
        bool ReadOnly { get; set;}
        object Entity { get; set;}
        bool Commit();
    }

}
