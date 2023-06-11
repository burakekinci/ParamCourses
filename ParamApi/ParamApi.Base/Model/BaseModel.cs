namespace ParamApi.Base.Model
{

    //INFO : Genel olarak "Data Modelleri"nde ortak olmasını istediğimiz
    //propertyleri BaseModel altında bu şekilde tanımlayabiliriz
    public class BaseModel
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
