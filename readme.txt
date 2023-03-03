1. Sử dụng file EShopperCD.bak để Restore Database vào SQL Server
2. Mở Project, thay đổi connectionString trong web.config của project Eshopper_CD và app.config của project Models (là Class Library) cho 
phù hợp với ConnectionString từ database đã Restore ở trên. Hoặc đơn giản hơn, Trong Folder Framework của Models, xóa tất cả các file, tạo
mới một ADO.NET Enity Data Model, lấy tên là EShoperDbContext (bắt buộc), chọn Code First sau đó chọn tất cả các bảng dữ liệu nằm trong
phần lựa chọn.
3. Khi đã kết nối được sql có thể chạy project.