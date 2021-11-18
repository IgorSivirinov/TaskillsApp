namespace Taskills.WebAppMVC.Models.CosmosDb.DbModels;

public class CosmosImage
{
    public Guid CosmosImageId { get; set; }
    public string ImageData { get; set; }

    public class MyByteClass
    {
        public byte Byte { get; set; }
    }
}