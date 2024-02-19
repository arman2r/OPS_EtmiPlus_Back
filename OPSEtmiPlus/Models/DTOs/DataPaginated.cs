namespace OPSEtmiPlus.Models.DTOs
{
    public class DataPaginated<T>
    {
        public int Total {  get; set; }
        public List<T> Data { get; set; }

        public DataPaginated(int total, List<T> data)
        {
            Total = total;
            Data = data;
        }
    }
}
