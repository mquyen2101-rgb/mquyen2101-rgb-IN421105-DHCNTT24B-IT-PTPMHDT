# EduHub — Hệ thống quản lý câu lạc bộ và sự kiện

## 1. Giới thiệu

EduHub là ứng dụng Console được xây dựng bằng C# nhằm hỗ trợ quản lý câu lạc bộ và sự kiện dành cho sinh viên Trường Đại học Đồng Tháp.

Hệ thống hỗ trợ các chức năng tạo câu lạc bộ, quản lý thành viên, tạo sự kiện, đăng ký tham gia sự kiện, xác nhận đăng ký, điểm danh và thống kê tình hình tham gia.

## 2. Công nghệ sử dụng

- Ngôn ngữ lập trình: C#
- Nền tảng: .NET 10 Console Application
- Phương pháp lập trình: Lập trình hướng đối tượng (OOP)
- Nullable Reference Types
- Mermaid dùng để mô tả sơ đồ lớp.

## 3. Thiết kế miền nghiệp vụ (Domain Design)

Hệ thống gồm 5 lớp nghiệp vụ chính:

- **Member:** Lưu trữ thông tin sinh viên, bao gồm họ tên, email, mã sinh viên và ngày tham gia.
- **Club:** Lưu trữ thông tin câu lạc bộ và quản lý danh sách thành viên.
- **Event:** Lưu trữ thông tin sự kiện, bao gồm tên sự kiện, thời gian, số lượng người tham gia tối đa và hình thức tổ chức.
- **Registration:** Quản lý thông tin đăng ký sự kiện và trạng thái đăng ký.
- **CheckIn:** Lưu thông tin điểm danh, thời gian điểm danh và phương thức điểm danh.

Các trạng thái đăng ký được định nghĩa trong `RegistrationStatus`, gồm `Pending` (đang chờ), `Confirmed` (đã xác nhận) và `Cancelled` (đã hủy).

Các phương thức điểm danh được định nghĩa trong `CheckInMethod`, gồm `QRCode` (mã QR) và `Manual` (điểm danh thủ công).

## 4. Cấu trúc dự án

```text
EduHub.Ch01/
├── Domain/
│   ├── Member.cs
│   ├── Club.cs
│   ├── Event.cs
│   ├── Registration.cs
│   └── CheckIn.cs
├── docs/
│   ├── user-stories.md
│   └── class-diagram.md
├── Program.cs
├── EduHub.Ch01.csproj
└── README.md
```

## 5. Hướng dẫn chạy chương trình

### Yêu cầu

- Cài đặt Visual Studio.
- Cài đặt .NET 10 SDK.

### Các bước thực hiện

1. Mở dự án `EduHub.Ch01` trong Visual Studio.
2. Chọn `EduHub.Ch01` làm dự án khởi chạy.
3. Chọn **Build → Build Solution** để biên dịch chương trình.
4. Nhấn **Ctrl + F5** để chạy chương trình.

Sau khi chạy, chương trình hiển thị thông tin câu lạc bộ, danh sách thành viên, thông tin sự kiện, trạng thái đăng ký, thông tin điểm danh và báo cáo tổng hợp.

## 6. Kết quả chạy thử

Chương trình tạo câu lạc bộ `Tech Club` với 3 thành viên và một sự kiện có tên `Workshop AI`.

Hai thành viên đăng ký tham gia sự kiện và cả hai đăng ký đều được xác nhận. Trong đó, một thành viên đã thực hiện điểm danh.

Kết quả thống kê dự kiến:

- Tổng số thành viên: 3
- Tổng số lượt đăng ký: 2
- Tổng số lượt điểm danh: 1
- Số đăng ký đã xác nhận: 2

### Hình ảnh minh họa

Chèn ảnh chụp màn hình kết quả chạy chương trình vào mục này.

Lưu ảnh tại `docs/demo-result.png`, sau đó thay dòng hướng dẫn trên bằng đoạn Markdown sau:

```markdown
![Kết quả chạy thử EduHub](docs/demo-result.png)
```

## 7. Tài liệu dự án

- [Tài liệu User Stories](docs/user-stories.md)
- [Sơ đồ lớp Class Diagram](docs/class-diagram.md)
