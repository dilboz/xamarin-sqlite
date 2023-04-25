using System;
using SQLite;

namespace App2.Model
{
    public class PersonModel
    {
        public string Id { get; set; }
        
        public string FullName { get; set; }
        
        public string Gender { get; set; }
        
        public string StatusId { get; set; }
        
        public string SocialStatusId { get; set; }
        
        public string EducationId { get; set; }
        
        public string InsertDate { get; set; }
        
        public string UserId { get; set; }
        
        public string VillageId { get; set; }
        
        public string DistrictId { get; set; }
        
        public string Age { get; set; }

        public string IsDisabled { get; set; }
        
        public string DisabledLevellId { get; set; }
        
        public string PasNumber { get; set; }
        
        public string DualCitizenship { get; set; }
        
        public string MigrationStatus { get; set; }
        
        public string CountryId { get; set; }
        
        public string LiderName { get; set; }

    }
}