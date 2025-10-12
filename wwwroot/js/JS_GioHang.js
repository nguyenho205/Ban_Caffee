document.addEventListener('DOMContentLoaded', function() {
        // 1. Lấy tất cả các nhóm quantity-selector trên trang
        const quantitySelectors = document.querySelectorAll('.quantity-selector');

        // 2. Lặp qua từng nhóm để thêm sự kiện
        quantitySelectors.forEach(selector => {
            const decreaseBtn = selector.querySelector('.quantity-btn:first-child');
            const increaseBtn = selector.querySelector('.quantity-btn:last-child');
            const quantityInput = selector.querySelector('.quantity-input');

            // 3. Thêm sự kiện click cho nút TĂNG (+)
            increaseBtn.addEventListener('click', () => {
                // Lấy giá trị hiện tại và chuyển thành số
                let currentValue = parseInt(quantityInput.value);
                // Tăng giá trị lên 1
                quantityInput.value = currentValue + 1;
            });

            // 4. Thêm sự kiện click cho nút GIẢM (-)
            decreaseBtn.addEventListener('click', () => {
                let currentValue = parseInt(quantityInput.value);
                // Chỉ giảm nếu giá trị lớn hơn 1
                if (currentValue > 1) {
                    quantityInput.value = currentValue - 1;
                }
            });
        });
    });

document.addEventListener('DOMContentLoaded', function() {
    // 1. Tìm tất cả các nút xóa có class là 'remove-item'
    const removeButtons = document.querySelectorAll('.remove-item');

    // 2. Lặp qua từng nút và gán sự kiện 'click' cho nó
    removeButtons.forEach(button => {
        button.addEventListener('click', function() {
            // 3. Khi nút được click, tìm phần tử cha '.cart-item' gần nhất...
            const cartItem = button.closest('.cart-item');
            
            // ... và xóa nó khỏi trang
            if (cartItem) {
                cartItem.remove();
            }

            // (Tùy chọn) Gọi hàm để cập nhật lại tổng tiền giỏ hàng
            // updateCartTotal(); 
        });
    });
});