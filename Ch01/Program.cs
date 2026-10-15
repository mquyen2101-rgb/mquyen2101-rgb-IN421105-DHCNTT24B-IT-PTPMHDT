
using System;
using System.Collections.Generic;
using System.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8;

const string ClubName = "Tech Club";
const string EventTitle = "Workshop AI";

Console.WriteLine("====================================");
Console.WriteLine("       EDHUB - QUAN LY SU KIEN");
Console.WriteLine("====================================");

// 1. Tao cau lac bo
Club club = Club.Create(
    ClubName,
    "Cau lac bo cong nghe thong tin");

Console.WriteLine("\n[1] TAO CAU LAC BO");
Console.WriteLine($"Ten CLB: {club.Name}");
Console.WriteLine($"Mo ta: {club.Description}");

// 2. Them 3 thanh vien
Member member1 = Member.Create(
    "Nguyen Van An", "an@example.com", "SV001");

Member member2 = Member.Create(
    "Tran Thi Binh", "binh@example.com", "SV002");

Member member3 = Member.Create(
    "Le Van Cuong", "cuong@example.com", "SV003");

club.AddMember(member1);
club.AddMember(member2);
club.AddMember(member3);

Console.WriteLine("\n[2] DANH SACH THANH VIEN");
foreach (Member member in club.Members)
{
    Console.WriteLine(
        $"{member.StudentCode} - {member.Name} - {member.Email}");
}

Console.WriteLine($"Tong so thanh vien: {club.MemberCount()}");

// 3. Tao su kien
Event event1 = Event.Create(
    club.Id,
    EventTitle,
    DateTime.Now.AddDays(7),
    50,
    false);

Console.WriteLine("\n[3] TAO SU KIEN");
Console.WriteLine($"Ten su kien: {event1.Title}");
Console.WriteLine($"Ngay to chuc: {event1.Date:dd/MM/yyyy HH:mm}");
Console.WriteLine($"Suc chua: {event1.Capacity}");
Console.WriteLine($"Hinh thuc: {(event1.IsOnline ? "Truc tuyen" : "Truc tiep")}");

// 4. Hai thanh vien dang ky va xac nhan
List<Registration> registrations = new();

Registration registration1 =
    Registration.Create(member1.Id, event1.Id);

Registration registration2 =
    Registration.Create(member2.Id, event1.Id);

registrations.Add(registration1);
registrations.Add(registration2);

Console.WriteLine("\n[4] DANG KY SU KIEN");
Console.WriteLine($"{member1.Name}: {registration1.Status}");
registration1.Confirm();

Console.WriteLine($"{member1.Name}: {registration1.Status}");

Console.WriteLine($"{member2.Name}: {registration2.Status}");
registration2.Confirm();

Console.WriteLine($"{member2.Name}: {registration2.Status}");

// 5. Mot thanh vien check-in
CheckIn checkIn1 = CheckIn.Create(
    registration1.Id,
    CheckInMethod.QRCode);

Console.WriteLine("\n[5] DIEM DANH");
Console.WriteLine(checkIn1.Summary());

// 6. Bao cao tham du
List<CheckIn> checkIns = new() { checkIn1 };

Console.WriteLine("\n[6] BAO CAO THAM DU");
Console.WriteLine($"Su kien: {event1.Title}");
Console.WriteLine($"Tong so dang ky: {registrations.Count}");
Console.WriteLine($"Tong so check-in: {checkIns.Count}");
Console.WriteLine("Danh sach nguoi da dang ky:");

foreach (Registration registration in registrations)
{
    Member? member = club.Members.FirstOrDefault(
        m => m.Id == registration.MemberId);

    if (member != null)
    {
        bool hasCheckedIn = checkIns.Any(
            c => c.RegistrationId == registration.Id);

        Console.WriteLine(
            $"- {member.Name} | {registration.Status} | " +
            $"Check-in: {(hasCheckedIn ? "Da diem danh" : "Chua diem danh")}");
    }
}

Console.WriteLine("\n====================================");
Console.WriteLine("       KET THUC CHUONG TRINH");
Console.WriteLine("====================================");
