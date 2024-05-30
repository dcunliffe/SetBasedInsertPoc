﻿namespace LHDS.UPRN.Domain.Models
{
    public class Addresses
    {
        public int Id { get; set; }

        public string? UPRN { get; set; }
        public string? UPSN { get; set; }
        public string? OrganisationName { get; set; }
        public string? DepartmentName { get; set; }
        public string? SubBuildingName { get; set; }
        public string? BuildingName { get; set; }
        public string? BuildingNumber { get; set; }
        public string? DependentThoroughfare { get; set; }
        public string? Thoroughfare { get; set; }
        public string? DoubleDependentLocality { get; set; }
        public string? DependentLocality { get; set; }
        public string? PostTown { get; set; }
        public string? PostalAddress { get; set; }
        public string? PostCode { get; set; }

        public string? LibPostalData { get; set; }
    }
}
