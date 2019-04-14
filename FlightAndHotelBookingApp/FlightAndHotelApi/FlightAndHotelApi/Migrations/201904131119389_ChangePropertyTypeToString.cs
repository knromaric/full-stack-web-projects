namespace FlightAndHotelApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropertyTypeToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlightAndHotels", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FlightAndHotels", "Details");
        }
    }
}
