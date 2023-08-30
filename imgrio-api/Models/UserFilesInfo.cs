namespace imgrio_api.Models
{
    public class UserFilesInfo
    {
        public UserFilesInfo(int count, int countToday)
        {
            Count = count;
            CountToday = countToday;
        }

        public int Count { get; set; }
        public int CountToday { get; set; }
    }
}
