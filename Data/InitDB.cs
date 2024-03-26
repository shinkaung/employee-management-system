using Microsoft.EntityFrameworkCore;
using EMS.Models;

namespace EMS.Data
{
    public static class InitDB
    {
        /*
            Dependency Injection (DI) is designed to work with instances of classes rather than static classes.
            This is because static classes and methods are associated with the type itself,
            and they cannot be instantiated or injected in the same way as instances of non-static classes.
        */
        public static void Initialize(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProduction);
            }
        }

        private static void SeedData(AppDbContext ctx, bool isProduction)
        {
            if (isProduction)
            {
                Console.WriteLine("Applying Migrations...");
                try
                {
                    ctx.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            if (!ctx.Departments.Any())
            {
                Console.WriteLine("========== Seeding Department Data ==========");
                ctx.Departments.AddRange(
                    new Department { DepartmentCode = "D001", DepartmentName = "Information Technology" },
                    new Department { DepartmentCode = "D002", DepartmentName = "Finance & Accounting" },
                    new Department { DepartmentCode = "D003", DepartmentName = "Human Resource" },
                    new Department { DepartmentCode = "D004", DepartmentName = "Sales & Marketing" },
                    new Department { DepartmentCode = "D005", DepartmentName = "Research & Development" },
                    new Department { DepartmentCode = "D006", DepartmentName = "Administration" },
                    new Department { DepartmentCode = "D007", DepartmentName = "Security" },
                    new Department { DepartmentCode = "D008", DepartmentName = "Manufacturing" },
                    new Department { DepartmentCode = "D009", DepartmentName = "Operation" },
                    new Department { DepartmentCode = "D010", DepartmentName = "Customer Service" },
                    new Department { DepartmentCode = "D011", DepartmentName = "Business Development" },
                    new Department { DepartmentCode = "D012", DepartmentName = "Logistics" }
                );
                ctx.SaveChanges();
                Console.WriteLine("========== Department Data Seeding Successful ==========");
            }
            else
            {
                Console.WriteLine("Department Data Already Existed");
            }

            if (!ctx.Units.Any())
            {
                Console.WriteLine("========== Seeding Unit Data ==========");
                ctx.Units.AddRange(
                    new Unit { UnitName = "Software Development", Description = "Responsible for designing, developing, and maintaining software applications tailored to meet organizational needs", DepartmentId = 1 },
                    new Unit { UnitName = "Infrastructure Management", Description = " Manages and maintains the organization's IT infrastructure, including networks, servers, and systems, ensuring reliability and performance", DepartmentId = 1 },
                    new Unit { UnitName = "Accounts Payable", Description = "Handles the timely and accurate processing of payments to suppliers and vendors, ensuring compliance with financial policies and regulations", DepartmentId = 2 },
                    new Unit { UnitName = "Financial Reporting", Description = "Prepares and analyzes financial statements, reports, and forecasts to support strategic decision-making and ensure regulatory compliance", DepartmentId = 2 },
                    new Unit { UnitName = "Recruitment and Talent Acquisition", Description = "Manages the recruitment process, including sourcing, screening, and onboarding new talent, while also developing strategies to attract and retain top performers", DepartmentId = 3 },
                    new Unit { UnitName = "Employee Relations and Compliance", Description = "Handles employee relations matters, ensures compliance with labor laws and regulations, and fosters a positive work environment through effective policies and practices", DepartmentId = 3 },
                    new Unit { UnitName = "Sales Strategy and Planning", Description = "Develops sales strategies, plans, and targets to drive revenue growth and market penetration, while also analyzing market trends and customer needs", DepartmentId = 4 },
                    new Unit { UnitName = "Digital Marketing and Social Media", Description = "Executes digital marketing campaigns, manages social media channels, and utilizes online platforms to enhance brand awareness, engagement, and lead generation", DepartmentId = 4 },
                    new Unit { UnitName = "Product Innovation", Description = " Leads the development of new products or services through research, prototyping, and testing, focusing on meeting customer needs and staying ahead of market trends", DepartmentId = 5 },
                    new Unit { UnitName = "Market Research", Description = "Conducts market research and analysis to identify opportunities, assess competition, and gather insights to inform product development, marketing strategies, and business decisions", DepartmentId = 5 },
                    new Unit { UnitName = "Office Management", Description = "Manages administrative tasks such as office supplies, facilities maintenance, and administrative support services to ensure smooth daily operations", DepartmentId = 6 },
                    new Unit { UnitName = "Facilities and Maintenance", Description = "Oversees the maintenance and upkeep of physical facilities, including buildings, equipment, and utilities, to ensure a safe and efficient work environment", DepartmentId = 6 },
                    new Unit { UnitName = "Physical Security", Description = "Implements measures to protect physical assets, premises, and personnel through surveillance, access control, and security protocols", DepartmentId = 7 },
                    new Unit { UnitName = "Information Security", Description = "Safeguards digital assets, data, and information systems from unauthorized access, breaches, and cyber threats through policies, procedures, and technologies", DepartmentId = 7 },
                    new Unit { UnitName = "Production Planning", Description = "Plans and schedules production activities, manages inventory levels, and optimizes resource allocation to meet production targets and customer demand", DepartmentId = 8 },
                    new Unit { UnitName = "Quality Control", Description = "Implements quality assurance processes, conducts inspections, and ensures adherence to quality standards and specifications throughout the manufacturing process", DepartmentId = 8 },
                    new Unit { UnitName = "Supply Chain Management", Description = "Manages the end-to-end supply chain, from procurement to distribution, to optimize efficiency, minimize costs, and ensure timely delivery of goods and services", DepartmentId = 9 },
                    new Unit { UnitName = "Process Improvement", Description = "Identifies inefficiencies, bottlenecks, and opportunities for optimization within operational processes, and implements initiatives to enhance productivity, quality, and customer satisfaction", DepartmentId = 9 },
                    new Unit { UnitName = "Customer Support", Description = "Provides frontline assistance to customers, resolves inquiries, issues, and complaints, and delivers exceptional service to enhance customer satisfaction and loyalty", DepartmentId = 10 },
                    new Unit { UnitName = "Service Excellence", Description = "Develops and implements strategies, training programs, and service standards to ensure consistent delivery of exceptional customer experiences across all touchpoints", DepartmentId = 10 },
                    new Unit { UnitName = "Partnership and Alliances", Description = "Identifies and cultivates strategic partnerships, alliances, and collaborations with other organizations to expand market reach, drive growth, and unlock new opportunities", DepartmentId = 11 },
                    new Unit { UnitName = "New Market Exploration", Description = "Conducts market research and feasibility studies to identify and assess new market opportunities, develops entry strategies, and drives initiatives to penetrate and establish presence in those markets", DepartmentId = 11 },
                    new Unit { UnitName = "Inventory Management", Description = "Manages inventory levels, replenishment processes, and stock control systems to ensure optimal inventory turnover, minimize stockouts, and reduce carrying costs", DepartmentId = 12 },
                    new Unit { UnitName = "Transportation and Distribution", Description = "Coordinates the movement of goods, materials, and products from suppliers to customers through efficient transportation and distribution networks, optimizing routes, modes, and delivery schedules", DepartmentId = 12 }
                );
                ctx.SaveChanges();
                Console.WriteLine("========== Unit Data Seeding Successful ==========");
            }
            else
            {
                Console.WriteLine("Unit Data Already Existed");
            }

            if (!ctx.Employees.Any())
            {
                Console.WriteLine("========== Seeding Employee Data ==========");
                ctx.Employees.AddRange(
                    new Employee { EmployeeId = "10001", FirstName = "John", LastName = "Doe", DateOfBirth = DateOnly.Parse("1990-05-15"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2020-01-10"), Email = "john.doe@example.com", Phone = "+65 9123 4567", Address = "123 Main Street, #01-234, Singapore 123456", UnitId = 1 },
                    new Employee { EmployeeId = "10002", FirstName = "Jane", LastName = "Smith", DateOfBirth = DateOnly.Parse("1985-08-20"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2018-03-25"), Email = "jane.smith@example.com", Phone = "+65 9876 5432", Address = "456 Orchard Road, #05-678, Singapore 654321", UnitId = 2 },
                    new Employee { EmployeeId = "10003", FirstName = "Mike", LastName = "Johnson", DateOfBirth = DateOnly.Parse("1992-11-03"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2019-07-18"), Email = "mike.johnson@example.com", Phone = "+65 8765 4321", Address = "789 Marina Bay, #10-111, Singapore 789012", UnitId = 4 },
                    new Employee { EmployeeId = "10004", FirstName = "Sara", LastName = "Lee", DateOfBirth = DateOnly.Parse("1988-04-12"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2021-05-30"), Email = "sara.lee@example.com", Phone = "+65 7654 3210", Address = "101 Raffles Place, #03-222, Singapore 101234", UnitId = 5 },
                    new Employee { EmployeeId = "10005", FirstName = "David", LastName = "Ng", DateOfBirth = DateOnly.Parse("1995-09-25"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2017-12-05"), Email = "david.ng@example.com", Phone = "+65 6543 2109", Address = "202 Serangoon Road, #08-333, Singapore 202345", UnitId = 9 },
                    new Employee { EmployeeId = "10006", FirstName = "Emily", LastName = "Tan", DateOfBirth = DateOnly.Parse("1993-02-18"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2022-02-15"), Email = "emily.tan@example.com", Phone = "+65 5432 1098", Address = "303 Bukit Timah, #12-444, Singapore 303456", UnitId = 14 },
                    new Employee { EmployeeId = "10007", FirstName = "Robert", LastName = "Wong", DateOfBirth = DateOnly.Parse("1984-07-07"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2016-10-22"), Email = "robert.wong@example.com", Phone = "+65 4321 0987", Address = "404 Jurong West, #15-555, Singapore 404567", UnitId = 24 },
                    new Employee { EmployeeId = "10008", FirstName = "Eva", LastName = "Lim", DateOfBirth = DateOnly.Parse("1998-12-30"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2023-08-08"), Email = "eva.lim@example.com", Phone = "+65 3210 9876", Address = "505 Holland Drive, #18-666, Singapore 505678", UnitId = 9 },
                    new Employee { EmployeeId = "10009", FirstName = "Chris", LastName = "Goh", DateOfBirth = DateOnly.Parse("1987-06-09"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2020-11-12"), Email = "chris.goh@example.com", Phone = "+65 2109 8765", Address = "606 East Coast, #21-777, Singapore 606789", UnitId = 10 },
                    new Employee { EmployeeId = "10010", FirstName = "Mia", LastName = "Chua", DateOfBirth = DateOnly.Parse("1991-03-27"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2018-04-28"), Email = "mia.chua@example.com", Phone = "+65 1098 7654", Address = "707 Woodlands Ave, #24-888, Singapore 707890", UnitId = 3 },
                    new Employee { EmployeeId = "10011", FirstName = "Kevin", LastName = "Tan", DateOfBirth = DateOnly.Parse("1994-06-14"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2019-02-08"), Email = "kevin.tan@example.com", Phone = "+65 9876 5432", Address = "123 Bukit Batok, #01-234, Singapore 123789", UnitId = 8 },
                    new Employee { EmployeeId = "10012", FirstName = "Sophie", LastName = "Lau", DateOfBirth = DateOnly.Parse("1989-09-03"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2020-07-15"), Email = "sophie.lau@example.com", Phone = "+65 8765 4321", Address = "456 Yishun Ave, #05-678, Singapore 456012", UnitId = 7 },
                    new Employee { EmployeeId = "10013", FirstName = "Jason", LastName = "Ong", DateOfBirth = DateOnly.Parse("1996-01-22"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2018-04-18"), Email = "jason.ong@example.com", Phone = "+65 7654 3210", Address = "789 Tampines Street, #10-111, Singapore 789345", UnitId = 17 },
                    new Employee { EmployeeId = "10014", FirstName = "Ella", LastName = "Chong", DateOfBirth = DateOnly.Parse("1986-12-08"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2022-01-30"), Email = "ella.chong@example.com", Phone = "+65 6543 2109", Address = "101 Clementi Road, #03-222, Singapore 101678", UnitId = 16 },
                    new Employee { EmployeeId = "10015", FirstName = "Tom", LastName = "Lim", DateOfBirth = DateOnly.Parse("1990-07-17"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2017-11-25"), Email = "tom.lim@example.com", Phone = "+65 5432 1098", Address = "202 Queenstown Drive, #08-333, Singapore 202901", UnitId = 5 },
                    new Employee { EmployeeId = "10016", FirstName = "Grace", LastName = "Yeo", DateOfBirth = DateOnly.Parse("1992-04-05"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2023-05-20"), Email = "grace.yeo@example.com", Phone = "+65 4321 0987", Address = "303 Bedok North, #12-444, Singapore 303234", UnitId = 2 },
                    new Employee { EmployeeId = "10017", FirstName = "Patrick", LastName = "Foo", DateOfBirth = DateOnly.Parse("1985-08-31"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2016-09-22"), Email = "patrick.foo@example.com", Phone = "+65 3210 9876", Address = "404 Sengkang West, #15-555, Singapore 404567", UnitId = 1 },
                    new Employee { EmployeeId = "10018", FirstName = "Nina", LastName = "Koh", DateOfBirth = DateOnly.Parse("1999-11-22"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2021-07-08"), Email = "nina.koh@example.com", Phone = "+65 2109 8765", Address = "505 Pasir Ris, #18-666, Singapore 505678", UnitId = 11 },
                    new Employee { EmployeeId = "10019", FirstName = "Alex", LastName = "Tay", DateOfBirth = DateOnly.Parse("1988-05-17"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2020-10-12"), Email = "alex.tay@example.com", Phone = "+65 1098 7654", Address = "606 Ang Mo Kio, #21-777, Singapore 606789", UnitId = 18 },
                    new Employee { EmployeeId = "10020", FirstName = "Helen", LastName = "Gan", DateOfBirth = DateOnly.Parse("1993-03-03"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2018-05-28"), Email = "helen.gan@example.com", Phone = "+65 9876 5432", Address = "707 Jalan Kayu, #24-888, Singapore 707012", UnitId = 8 },
                    new Employee { EmployeeId = "10021", FirstName = "Ryan", LastName = "Liew", DateOfBirth = DateOnly.Parse("1991-08-11"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2019-03-18"), Email = "ryan.liew@example.com", Phone = "+65 8765 4321", Address = "123 Serangoon Central, #01-234, Singapore 123789", UnitId = 23 },
                    new Employee { EmployeeId = "10022", FirstName = "Lily", LastName = "Tan", DateOfBirth = DateOnly.Parse("1986-10-29"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2020-08-22"), Email = "lily.tan@example.com", Phone = "+65 7654 3210", Address = "456 Woodlands Street, #05-678, Singapore 456012", UnitId = 21 },
                    new Employee { EmployeeId = "10023", FirstName = "Daniel", LastName = "Teo", DateOfBirth = DateOnly.Parse("1997-04-17"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2018-05-28"), Email = "daniel.teo@example.com", Phone = "+65 6543 2109", Address = "789 Jurong East Ave, #10-111, Singapore 789345", UnitId = 21 },
                    new Employee { EmployeeId = "10024", FirstName = "Catherine", LastName = "Ng", DateOfBirth = DateOnly.Parse("1989-12-05"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2022-02-10"), Email = "catherine.ng@example.com", Phone = "+65 5432 1098", Address = "101 Orchard Boulevard, #03-222, Singapore 101678", UnitId = 12 },
                    new Employee { EmployeeId = "10025", FirstName = "Andrew", LastName = "Wu", DateOfBirth = DateOnly.Parse("1994-03-21"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2017-12-15"), Email = "andrew.wu@example.com", Phone = "+65 4321 0987", Address = "202 Bukit Panjang, #08-333, Singapore 202901", UnitId = 18 },
                    new Employee { EmployeeId = "10026", FirstName = "Olivia", LastName = "Chen", DateOfBirth = DateOnly.Parse("1992-06-19"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2023-06-20"), Email = "olivia.chen@example.com", Phone = "+65 3210 9876", Address = "303 Chinatown Street, #12-444, Singapore 303234", UnitId = 16 },
                    new Employee { EmployeeId = "10027", FirstName = "Benjamin", LastName = "Lam", DateOfBirth = DateOnly.Parse("1987-09-14"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2016-10-02"), Email = "benjamin.lam@example.com", Phone = "+65 2109 8765", Address = "404 River Valley, #15-555, Singapore 404567", UnitId = 6 },
                    new Employee { EmployeeId = "10028", FirstName = "Emma", LastName = "Cheong", DateOfBirth = DateOnly.Parse("2000-02-28"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2021-08-18"), Email = "emma.cheong@example.com", Phone = "+65 1098 7654", Address = "505 Little India, #18-666, Singapore 505678", UnitId = 3 },
                    new Employee { EmployeeId = "10029", FirstName = "Victor", LastName = "Koh", DateOfBirth = DateOnly.Parse("1988-07-09"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2020-11-22"), Email = "victor.koh@example.com", Phone = "+65 9876 5432", Address = "606 Bishan Street, #21-777, Singapore 606789", UnitId = 9 },
                    new Employee { EmployeeId = "10030", FirstName = "Jasmine", LastName = "Ooi", DateOfBirth = DateOnly.Parse("1995-01-15"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2018-04-30"), Email = "jasmine.ooi@example.com", Phone = "+65 8765 4321", Address = "707 Telok Blangah, #24-888, Singapore 707012", UnitId = 18 },
                    new Employee { EmployeeId = "10031", FirstName = "Derek", LastName = "Tan", DateOfBirth = DateOnly.Parse("1990-04-12"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2019-02-28"), Email = "derek.tan@example.com", Phone = "+65 7654 3210", Address = "123 Hougang Ave, #01-234, Singapore 123789", UnitId = 24 },
                    new Employee { EmployeeId = "10032", FirstName = "Sophia", LastName = "Wong", DateOfBirth = DateOnly.Parse("1985-11-18"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2020-09-15"), Email = "sophia.wong@example.com", Phone = "+65 6543 2109", Address = "456 Upper Thomson Road, #05-678, Singapore 456012", UnitId = 22 },
                    new Employee { EmployeeId = "10033", FirstName = "Leo", LastName = "Ng", DateOfBirth = DateOnly.Parse("1993-08-27"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2018-06-18"), Email = "leo.ng@example.com", Phone = "+65 5432 1098", Address = "789 Punggol Drive, #10-111, Singapore 789345", UnitId = 22 },
                    new Employee { EmployeeId = "10034", FirstName = "Alice", LastName = "Lim", DateOfBirth = DateOnly.Parse("1988-02-03"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2022-03-05"), Email = "alice.lim@example.com", Phone = "+65 4321 0987", Address = "101 Bukit Merah Lane, #03-222, Singapore 101678", UnitId = 23 },
                    new Employee { EmployeeId = "10035", FirstName = "Steven", LastName = "Goh", DateOfBirth = DateOnly.Parse("1996-05-29"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2017-11-30"), Email = "steven.goh@example.com", Phone = "+65 3210 9876", Address = "202 Choa Chu Kang Ave, #08-333, Singapore 202901", UnitId = 12 },
                    new Employee { EmployeeId = "10036", FirstName = "Evelyn", LastName = "Chin", DateOfBirth = DateOnly.Parse("1991-12-14"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2023-07-20"), Email = "evelyn.chin@example.com", Phone = "+65 2109 8765", Address = "303 Toa Payoh, #12-444, Singapore 303234", UnitId = 10 },
                    new Employee { EmployeeId = "10037", FirstName = "Jack", LastName = "Yap", DateOfBirth = DateOnly.Parse("1986-10-05"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2016-11-02"), Email = "jack.yap@example.com", Phone = "+65 1098 7654", Address = "404 Simei Street, #15-555, Singapore 404567", UnitId = 19 },
                    new Employee { EmployeeId = "10038", FirstName = "Hannah", LastName = "Lim", DateOfBirth = DateOnly.Parse("1998-04-30"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2021-09-18"), Email = "hannah.lim@example.com", Phone = "+65 9876 5432", Address = "505 Bukit Timah Road, #18-666, Singapore 505678", UnitId = 8 },
                    new Employee { EmployeeId = "10039", FirstName = "Max", LastName = "Tan", DateOfBirth = DateOnly.Parse("1987-07-22"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2020-12-22"), Email = "max.tan@example.com", Phone = "+65 8765 4321", Address = "606 MacPherson Road, #21-777, Singapore 606789", UnitId = 21 },
                    new Employee { EmployeeId = "10040", FirstName = "Sophie", LastName = "Chia", DateOfBirth = DateOnly.Parse("1992-03-08"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2018-05-02"), Email = "sophie.chia@example.com", Phone = "+65 1098 7654", Address = "707 Bukit Batok, #24-888, Singapore 707012", UnitId = 22 },
                    new Employee { EmployeeId = "10041", FirstName = "Chris", LastName = "Kwok", DateOfBirth = DateOnly.Parse("1993-06-14"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2019-03-28"), Email = "chris.kwok@example.com", Phone = "+65 7654 3210", Address = "123 Tiong Bahru Road, #01-234, Singapore 123789", UnitId = 23 },
                    new Employee { EmployeeId = "10042", FirstName = "Natalie", LastName = "Leong", DateOfBirth = DateOnly.Parse("1988-09-03"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2020-10-15"), Email = "natalie.leong@example.com", Phone = "+65 6543 2109", Address = "456 Geylang Road, #05-678, Singapore 456012", UnitId = 24 },
                    new Employee { EmployeeId = "10043", FirstName = "Vincent", LastName = "Chong", DateOfBirth = DateOnly.Parse("1997-02-17"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2018-07-28"), Email = "vincent.chong@example.com", Phone = "+65 5432 1098", Address = "789 Joo Chiat Road, #10-111, Singapore 789345", UnitId = 17 },
                    new Employee { EmployeeId = "10044", FirstName = "Grace", LastName = "Koh", DateOfBirth = DateOnly.Parse("1989-12-05"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2022-04-10"), Email = "grace.koh@example.com", Phone = "+65 4321 0987", Address = "101 Lavender Street, #03-222, Singapore 101678", UnitId = 17 },
                    new Employee { EmployeeId = "10045", FirstName = "Raymond", LastName = "Wu", DateOfBirth = DateOnly.Parse("1994-03-21"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2017-12-15"), Email = "raymond.wu@example.com", Phone = "+65 3210 9876", Address = "202 Boon Lay Drive, #08-333, Singapore 202901", UnitId = 15 },
                    new Employee { EmployeeId = "10046", FirstName = "Sylvia", LastName = "Tan", DateOfBirth = DateOnly.Parse("1992-06-19"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2023-08-20"), Email = "sylvia.tan@example.com", Phone = "+65 2109 8765", Address = "303 Jalan Besar, #12-444, Singapore 303234", UnitId = 13 },
                    new Employee { EmployeeId = "10047", FirstName = "Paul", LastName = "Ng", DateOfBirth = DateOnly.Parse("1987-09-14"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2016-12-02"), Email = "paul.ng@example.com", Phone = "+65 1098 7654", Address = "404 Kallang Road, #15-555, Singapore 404567", UnitId = 12 }
                    // new Employee { EmployeeId = "10048", FirstName = "Eva", LastName = "Lim", DateOfBirth = DateOnly.Parse("2000-02-28"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2021-10-18"), Email = "eva.lim@example.com", Phone = "+65 9876 5432", Address = "505 Beach Road, #18-666, Singapore 505678" },
                    // new Employee { EmployeeId = "10049", FirstName = "Timothy", LastName = "Yap", DateOfBirth = DateOnly.Parse("1988-07-09"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2021-01-22"), Email = "timothy.yap@example.com", Phone = "+65 8765 4321", Address = "606 Marine Parade, #21-777, Singapore 606789" },
                    // new Employee { EmployeeId = "10050", FirstName = "Rachel", LastName = "Ong", DateOfBirth = DateOnly.Parse("1995-01-15"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2018-06-30"), Email = "rachel.ong@example.com", Phone = "+65 1098 7654", Address = "707 Serangoon North, #24-888, Singapore 707012" },
                    // new Employee { EmployeeId = "10051", FirstName = "Michael", LastName = "Chen", DateOfBirth = DateOnly.Parse("1993-11-11"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2019-08-18"), Email = "michael.chen@example.com", Phone = "+65 9876 5432", Address = "123 Ang Mo Kio Ave, #01-234, Singapore 123789" },
                    // new Employee { EmployeeId = "10052", FirstName = "Amanda", LastName = "Neo", DateOfBirth = DateOnly.Parse("1998-02-25"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2022-03-22"), Email = "amanda.neo@example.com", Phone = "+65 8765 4321", Address = "456 Tampines Street, #05-678, Singapore 456012" },
                    // new Employee { EmployeeId = "10053", FirstName = "Eric", LastName = "Wang", DateOfBirth = DateOnly.Parse("1986-09-08"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2017-10-15"), Email = "eric.wang@example.com", Phone = "+65 7654 3210", Address = "789 Clementi Road, #10-111, Singapore 789345" },
                    // new Employee { EmployeeId = "10054", FirstName = "Michelle", LastName = "Lau", DateOfBirth = DateOnly.Parse("1991-04-20"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2018-07-30"), Email = "michelle.lau@example.com", Phone = "+65 6543 2109", Address = "101 Jurong West, #03-222, Singapore 101678" },
                    // new Employee { EmployeeId = "10055", FirstName = "Adam", LastName = "Tan", DateOfBirth = DateOnly.Parse("1996-06-05"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2023-05-20"), Email = "adam.tan@example.com", Phone = "+65 5432 1098", Address = "202 Bukit Batok, #08-333, Singapore 202901" },
                    // new Employee { EmployeeId = "10056", FirstName = "Stephanie", LastName = "Koh", DateOfBirth = DateOnly.Parse("1992-01-30"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2018-09-18"), Email = "stephanie.koh@example.com", Phone = "+65 4321 0987", Address = "303 Ang Mo Kio Ave, #12-444, Singapore 303234" },
                    // new Employee { EmployeeId = "10057", FirstName = "Jason", LastName = "Lim", DateOfBirth = DateOnly.Parse("1987-07-15"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2016-11-22"), Email = "jason.lim@example.com", Phone = "+65 3210 9876", Address = "404 Serangoon Central, #15-555, Singapore 404567" },
                    // new Employee { EmployeeId = "10058", FirstName = "Cynthia", LastName = "Gan", DateOfBirth = DateOnly.Parse("1999-08-18"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2021-02-12"), Email = "cynthia.gan@example.com", Phone = "+65 2109 8765", Address = "505 Bedok North, #18-666, Singapore 505678" },
                    // new Employee { EmployeeId = "10059", FirstName = "Greg", LastName = "Lau", DateOfBirth = DateOnly.Parse("1988-05-01"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2020-09-22"), Email = "greg.lau@example.com", Phone = "+65 1098 7654", Address = "606 Telok Blangah, #21-777, Singapore 606789" },
                    // new Employee { EmployeeId = "10060", FirstName = "Samantha", LastName = "Chua", DateOfBirth = DateOnly.Parse("1993-03-10"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2018-10-30"), Email = "samantha.chua@example.com", Phone = "+65 9876 5432", Address = "707 Toa Payoh, #24-888, Singapore 707012" },
                    // new Employee { EmployeeId = "10061", FirstName = "Peter", LastName = "Tay", DateOfBirth = DateOnly.Parse("1991-09-22"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2019-04-28"), Email = "peter.tay@example.com", Phone = "+65 8765 4321", Address = "123 Yishun Street, #01-234, Singapore 123789" },
                    // new Employee { EmployeeId = "10062", FirstName = "Rachel", LastName = "Kwok", DateOfBirth = DateOnly.Parse("1986-12-15"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2020-11-15"), Email = "rachel.kwok@example.com", Phone = "+65 7654 3210", Address = "456 Bukit Panjang, #05-678, Singapore 456012" },
                    // new Employee { EmployeeId = "10063", FirstName = "Patrick", LastName = "Ong", DateOfBirth = DateOnly.Parse("1996-02-17"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2018-08-28"), Email = "patrick.ong@example.com", Phone = "+65 6543 2109", Address = "789 Clementi Ave, #10-111, Singapore 789345" },
                    // new Employee { EmployeeId = "10064", FirstName = "Vanessa", LastName = "Tan", DateOfBirth = DateOnly.Parse("1989-11-30"), Gender = Gender.Female, JoinedDate = DateOnly.Parse("2022-05-10"), Email = "vanessa.tan@example.com", Phone = "+65 5432 1098", Address = "101 Jurong East Street, #03-222, Singapore 101678" },
                    // new Employee { EmployeeId = "10065", FirstName = "Brandon", LastName = "Lee", DateOfBirth = DateOnly.Parse("1994-04-21"), Gender = Gender.Male, JoinedDate = DateOnly.Parse("2017-10-15"), Email = "brandon.lee@example.com", Phone = "+65 4321 0987", Address = "202 Tampines Ave, #08-333, Singapore 202901" }
                );
                ctx.SaveChanges();
                Console.WriteLine("========== Employee Data Seeding Successful ==========");
            }
            else
            {
                Console.WriteLine("Employee Data Already Existed");
            }
        }
    }
}