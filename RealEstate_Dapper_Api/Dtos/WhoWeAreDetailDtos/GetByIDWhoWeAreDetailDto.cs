﻿namespace RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos
{
    public class GetByIDWhoWeAreDetailDto
    {
        public int WhoWeAreDetailID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public bool Status { get; set; }

    }
}