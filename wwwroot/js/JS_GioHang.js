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