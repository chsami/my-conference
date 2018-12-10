using System;

namespace ConferenceApi.Domain
{
    public class Conference
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public Category Category { get; set; }
    }
}
