namespace Game21.Models
{
    public class PaginationModel
    {
        public uint PageNumber { get; set; }
        
        public uint PageSize { get; set; }

        public PaginationModel()
        {
            PageSize = 10;
        }
    }
}