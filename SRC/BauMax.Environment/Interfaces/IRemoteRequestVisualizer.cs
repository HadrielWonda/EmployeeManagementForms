namespace Baumax.Environment.Interfaces
{
	public interface IRemoteRequestVisualizer
	{
		bool Visualizing { get; set; }
        void UpdateProgress();
	}
}