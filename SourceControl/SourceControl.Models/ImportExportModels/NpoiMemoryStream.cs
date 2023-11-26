namespace SourceControl.Models.ImportExportModels;

public class NpoiMemoryStream : MemoryStream
{
	public NpoiMemoryStream()
	{
		this.AllowClose = true;
	}

    public bool AllowClose { get; set; }

    public override void Close()
    {
		if (this.AllowClose)
		{
            base.Close();
        }
    }
}
