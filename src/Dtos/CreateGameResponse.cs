﻿namespace GamesCatalogApi.Dtos
{
    public class CreateGameResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
    }
}