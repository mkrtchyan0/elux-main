﻿namespace Elux.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid ExpertId { get; set; }
        public int Day { get; set; }
        public int StartingTime { get; set; }
        public int EndingTime { get; set; }
    }
}
