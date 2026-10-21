# Phân tích vi phạm SOLID trong ClubManager

File nguồn: `starter/Ch02.Refactor/ClubManager.cs`.

## 1. SRP - Single Responsibility Principle

- Vị trí: dòng 35-64, phương thức `CreateClub`.
- Vi phạm: Phương thức vừa kiểm tra dữ liệu (dòng 37-41), tạo và lưu câu lạc bộ (dòng 43-45), ghi log (dòng 47-48), vừa gửi thông báo (dòng 50-63).
- Hậu quả: Một phương thức có nhiều lý do để thay đổi. Sửa quy tắc kiểm tra, cách lưu dữ liệu hoặc cách gửi thông báo đều có thể ảnh hưởng cùng một phương thức.
- Cách khắc phục: Tách nghiệp vụ vào `ClubService`, lưu trữ qua `IClubRepository`, ghi log qua `IAppLogger` và gửi thông báo qua `INotificationService`.

## 2. OCP - Open/Closed Principle

- Vị trí: dòng 50-63 trong `CreateClub`; dòng 81-83 trong `AddMemberToClub`.
- Vi phạm: Việc lựa chọn thông báo dựa trên các nhánh `if/else` Gmail/Yahoo và các lệnh gửi thông báo cố định.
- Hậu quả: Khi thêm kênh thông báo hoặc thay đổi cách gửi, phải sửa mã nguồn của phương thức hiện tại, tăng nguy cơ ảnh hưởng chức năng cũ.
- Cách khắc phục: Dùng `INotificationServiceFactory` để tạo dịch vụ theo `NotificationChannel`.

## 3. DIP - Dependency Inversion Principle

- Vị trí: dòng 48, 79, 94 và 111.
- Vi phạm: `ClubManager` gọi trực tiếp `File.AppendAllText` để ghi log thay vì phụ thuộc vào một abstraction.
- Hậu quả: Khó thay đổi cơ chế ghi log, khó thay thế việc ghi file bằng đối tượng giả khi kiểm thử.
- Cách khắc phục: Khai báo `IAppLogger`, triển khai logger cụ thể và truyền logger qua constructor của service.

## 4. SRP và OCP trong tạo sự kiện

- Vị trí: dòng 88-98, đặc biệt dòng 96-97.
- Vi phạm: `CreateEvent` vừa tạo sự kiện vừa tự duyệt danh sách thành viên để quyết định gửi thông báo.
- Hậu quả: Logic tạo sự kiện bị gắn với cách gửi email. Khi thay đổi cách thông báo, phải sửa phương thức tạo sự kiện.
- Cách khắc phục: Chuyển nghiệp vụ sang `EventService`, dùng `IEventObserver` để thông báo cho `EmailNotifier` và `LogNotifier`.

## 5. SRP và OCP trong báo cáo

- Vị trí: dòng 103-113, đặc biệt dòng 105-111.
- Vi phạm: `PrintClubReport` vừa tổng hợp số lượng thành viên, định dạng và in báo cáo, vừa ghi log.
- Hậu quả: Muốn thêm định dạng CSV hoặc định dạng khác phải sửa phương thức hiện tại; việc tổng hợp dữ liệu và xuất báo cáo khó kiểm thử riêng.
- Cách khắc phục: Tách `ReportService` và sử dụng `IReportStrategy`, với `ConsoleReportStrategy` và `CsvReportStrategy`.

## 6. ISP - Interface Segregation Principle

- Vị trí: thiết kế tổng thể của `ClubManager` tại dòng 28-116.
- Vi phạm: Một lớp tập trung các thao tác quản lý CLB, thành viên, sự kiện, báo cáo và ghi log thay vì phân tách trách nhiệm qua các hợp đồng riêng.
- Hậu quả: Các phần chỉ cần một nhóm chức năng vẫn phụ thuộc vào lớp có nhiều trách nhiệm không liên quan; khó bảo trì và kiểm thử từng phần.
- Cách khắc phục: Phân tách interface theo chức năng, ví dụ `IClubRepository`, `IMemberRepository`, `IEventRepository`, `IAppLogger` và `INotificationService`.

## Kết luận

`ClubManager` là một God class, vi phạm rõ nhất SRP, OCP và DIP. Việc tách service, repository, logger, notification và report strategy giúp giảm phụ thuộc, dễ kiểm thử và mở rộng hệ thống.
