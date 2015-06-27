namespace SimpleSupport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        CaseId = c.Int(nullable: false, identity: true),
                        CaseNumber = c.String(),
                        AspNetUserId = c.String(),
                    })
                .PrimaryKey(t => t.CaseId);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        ChildId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Overnights = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThirdPartyCustody = c.Boolean(nullable: false),
                        Case_CaseId = c.Int(),
                    })
                .PrimaryKey(t => t.ChildId)
                .ForeignKey("dbo.Cases", t => t.Case_CaseId)
                .Index(t => t.Case_CaseId);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        PartyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HealthCareAmount = c.Decimal(nullable: false, precision: 8, scale: 2),
                        ChildCareAmount = c.Decimal(nullable: false, precision: 8, scale: 2),
                        Exemptions = c.Short(nullable: false),
                        ExemptionsUnder17 = c.Short(nullable: false),
                        AdditionalChildren = c.Short(nullable: false),
                        Case_CaseId = c.Int(),
                        CityTax_CityTaxId = c.Int(),
                        FilingStatus_FilingStatusId = c.Int(),
                        PartyType_PartyTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.PartyId)
                .ForeignKey("dbo.Cases", t => t.Case_CaseId)
                .ForeignKey("dbo.CityTaxes", t => t.CityTax_CityTaxId)
                .ForeignKey("dbo.FilingStatus", t => t.FilingStatus_FilingStatusId)
                .ForeignKey("dbo.PartyTypes", t => t.PartyType_PartyTypeId)
                .Index(t => t.Case_CaseId)
                .Index(t => t.CityTax_CityTaxId)
                .Index(t => t.FilingStatus_FilingStatusId)
                .Index(t => t.PartyType_PartyTypeId);
            
            CreateTable(
                "dbo.CityTaxes",
                c => new
                    {
                        CityTaxId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TaxRate = c.Decimal(nullable: false, precision: 6, scale: 3),
                    })
                .PrimaryKey(t => t.CityTaxId);
            
            CreateTable(
                "dbo.Deductions",
                c => new
                    {
                        DeductionId = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 8, scale: 2),
                        DeductionType_DeductionTypeId = c.Int(),
                        Party_PartyId = c.Int(),
                    })
                .PrimaryKey(t => t.DeductionId)
                .ForeignKey("dbo.DeductionTypes", t => t.DeductionType_DeductionTypeId)
                .ForeignKey("dbo.Parties", t => t.Party_PartyId)
                .Index(t => t.DeductionType_DeductionTypeId)
                .Index(t => t.Party_PartyId);
            
            CreateTable(
                "dbo.DeductionTypes",
                c => new
                    {
                        DeductionTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        FederalTax = c.Boolean(nullable: false),
                        NIITax = c.Boolean(nullable: false),
                        AMTTax = c.Boolean(nullable: false),
                        SETax = c.Boolean(nullable: false),
                        StateTax = c.Boolean(nullable: false),
                        FICA = c.Boolean(nullable: false),
                        CityTax = c.Boolean(nullable: false),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.DeductionTypeId);
            
            CreateTable(
                "dbo.FilingStatus",
                c => new
                    {
                        FilingStatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.FilingStatusId);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        IncomeId = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 8, scale: 2),
                        IncomeType_IncomeTypeId = c.Int(),
                        Party_PartyId = c.Int(),
                    })
                .PrimaryKey(t => t.IncomeId)
                .ForeignKey("dbo.IncomeTypes", t => t.IncomeType_IncomeTypeId)
                .ForeignKey("dbo.Parties", t => t.Party_PartyId)
                .Index(t => t.IncomeType_IncomeTypeId)
                .Index(t => t.Party_PartyId);
            
            CreateTable(
                "dbo.IncomeTypes",
                c => new
                    {
                        IncomeTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        FederalTax = c.Boolean(nullable: false),
                        NIITax = c.Boolean(nullable: false),
                        AMTTax = c.Boolean(nullable: false),
                        SETax = c.Boolean(nullable: false),
                        StateTax = c.Boolean(nullable: false),
                        FICA = c.Boolean(nullable: false),
                        CityTax = c.Boolean(nullable: false),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.IncomeTypeId);
            
            CreateTable(
                "dbo.PartyTypes",
                c => new
                    {
                        PartyTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.PartyTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parties", "PartyType_PartyTypeId", "dbo.PartyTypes");
            DropForeignKey("dbo.Incomes", "Party_PartyId", "dbo.Parties");
            DropForeignKey("dbo.Incomes", "IncomeType_IncomeTypeId", "dbo.IncomeTypes");
            DropForeignKey("dbo.Parties", "FilingStatus_FilingStatusId", "dbo.FilingStatus");
            DropForeignKey("dbo.Deductions", "Party_PartyId", "dbo.Parties");
            DropForeignKey("dbo.Deductions", "DeductionType_DeductionTypeId", "dbo.DeductionTypes");
            DropForeignKey("dbo.Parties", "CityTax_CityTaxId", "dbo.CityTaxes");
            DropForeignKey("dbo.Parties", "Case_CaseId", "dbo.Cases");
            DropForeignKey("dbo.Children", "Case_CaseId", "dbo.Cases");
            DropIndex("dbo.Incomes", new[] { "Party_PartyId" });
            DropIndex("dbo.Incomes", new[] { "IncomeType_IncomeTypeId" });
            DropIndex("dbo.Deductions", new[] { "Party_PartyId" });
            DropIndex("dbo.Deductions", new[] { "DeductionType_DeductionTypeId" });
            DropIndex("dbo.Parties", new[] { "PartyType_PartyTypeId" });
            DropIndex("dbo.Parties", new[] { "FilingStatus_FilingStatusId" });
            DropIndex("dbo.Parties", new[] { "CityTax_CityTaxId" });
            DropIndex("dbo.Parties", new[] { "Case_CaseId" });
            DropIndex("dbo.Children", new[] { "Case_CaseId" });
            DropTable("dbo.PartyTypes");
            DropTable("dbo.IncomeTypes");
            DropTable("dbo.Incomes");
            DropTable("dbo.FilingStatus");
            DropTable("dbo.DeductionTypes");
            DropTable("dbo.Deductions");
            DropTable("dbo.CityTaxes");
            DropTable("dbo.Parties");
            DropTable("dbo.Children");
            DropTable("dbo.Cases");
        }
    }
}
