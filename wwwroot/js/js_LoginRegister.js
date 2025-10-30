document.addEventListener("DOMContentLoaded", function () {

    // ===== FORM ĐĂNG NHẬP =====
    const loginForm = document.querySelector('form[action*="LoginSubmit"]');
    if (loginForm) {
        loginForm.addEventListener("submit", function (e) {
            const email = document.getElementById("loginEmail").value.trim();
            const password = document.getElementById("loginPassword").value.trim();

            // Kiểm tra rỗng
            if (!email || !password) {
                e.preventDefault();
                alert("Vui lòng nhập đầy đủ Email và Mật khẩu!");
                return;
            }

            // Kiểm tra định dạng email
            const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailPattern.test(email)) {
                e.preventDefault();
                alert("Email không hợp lệ!");
                return;
            }

            // Kiểm tra độ dài mật khẩu
            if (password.length < 6) {
                e.preventDefault();
                alert("Mật khẩu phải có ít nhất 6 ký tự!");
                return;
            }

            
        });
    }


    // ===== FORM ĐĂNG KÝ =====
    const registerForm = document.querySelector('form[action*="RegisterSubmit"]');
    if (registerForm) {
        registerForm.addEventListener("submit", function (e) {
            const name = document.getElementById("registerName").value.trim();
            const email = document.getElementById("registerEmail").value.trim();
            const password = document.getElementById("registerPassword").value.trim();
            const confirmPassword = document.getElementById("confirmRegisterPassword").value.trim();

            // Kiểm tra rỗng
            if (!name || !email || !password || !confirmPassword) {
                e.preventDefault();
                alert("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kiểm tra định dạng email
            const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailPattern.test(email)) {
                e.preventDefault();
                alert("Email không hợp lệ!");
                return;
            }

            // Kiểm tra độ dài mật khẩu
            if (password.length < 6) {
                e.preventDefault();
                alert("Mật khẩu phải có ít nhất 6 ký tự!");
                return;
            }

            // Kiểm tra trùng mật khẩu
            if (password !== confirmPassword) {
                e.preventDefault();
                alert("Mật khẩu xác nhận không khớp!");
                return;
            }

            
        });
    }

});
