    document.addEventListener('DOMContentLoaded', function () {
        // --- CHỌN CÁC PHẦN TỬ HTML CẦN THIẾT ---
        const addToCartButtons = document.querySelectorAll('.add-to-cart-btn');
        const cartItemsContainer = document.querySelector('.cart-items');
        const totalPriceElement = document.querySelector('.total-price');

        // =================================================================
        // HÀM TÍNH TOÁN VÀ CẬP NHẬT TỔNG TIỀN (AN TOÀN)
        // =================================================================
        function updateCartTotal() {
            let total = 0;
            const allCartItems = cartItemsContainer.querySelectorAll('.cart-item');

            allCartItems.forEach(item => {
                // Lấy giá từ data-price và số lượng từ input
                const priceValue = parseFloat(item.dataset.price);
                const quantityValue = parseInt(item.querySelector('.quantity-input').value);

                // **SỬA LỖI NaN**: Nếu giá hoặc số lượng không hợp lệ, coi như chúng bằng 0
                const price = isNaN(priceValue) ? 0 : priceValue;
                const quantity = isNaN(quantityValue) ? 0 : quantityValue;

                total += price * quantity;
            });

            // Định dạng và hiển thị tổng tiền
            totalPriceElement.textContent = `${total.toLocaleString('vi-VN')}₫`;
        }

        // =================================================================
        // HÀM XỬ LÝ KHI THÊM SẢN PHẨM TỪ BÊN NGOÀI
        // =================================================================
        function handleAddToCartClick(event) {
            const productCard = event.target.closest('.product-card');
            if (!productCard) return;

            const productId = productCard.dataset.id;
            const productName = productCard.dataset.name;
            const productPrice = parseFloat(productCard.dataset.price);
            const productImageSrc = productCard.querySelector('img').src;

            const existingCartItem = cartItemsContainer.querySelector(`.cart-item[data-id="${productId}"]`);

            if (existingCartItem) {
                const quantityInput = existingCartItem.querySelector('.quantity-input');
                quantityInput.value = parseInt(quantityInput.value) + 1;
            } else {
                // Tạo sản phẩm mới với đầy đủ data-id và data-price
                const newItemHTML = `
                    <div class="cart-item" data-id="${productId}" data-price="${productPrice}">
                        <button class="remove-item">&times;</button>
                        <img src="${productImageSrc}" alt="${productName}" class="product-image">
                        <div class="product-details">
                            <p class="product-name">${productName}</p>
                        </div>
                        <p class="product-price">${productPrice.toLocaleString('vi-VN')}₫</p>
                        <div class="quantity-selector">
                            <button class="quantity-btn">-</button>
                            <input type="text" value="1" class="quantity-input">
                            <button class="quantity-btn">+</button>
                        </div>
                    </div>`;
                cartItemsContainer.insertAdjacentHTML('beforeend', newItemHTML);
            }
            
            updateCartTotal();
        }

        // =================================================================
        // GÁN CÁC SỰ KIỆN
        // =================================================================

        addToCartButtons.forEach(button => {
            button.addEventListener('click', handleAddToCartClick);
        });

        cartItemsContainer.addEventListener('click', function (event) {
            const target = event.target;
            const cartItem = target.closest('.cart-item');

            if (!cartItem) return;

            if (target.classList.contains('quantity-btn')) {
                const quantityInput = cartItem.querySelector('.quantity-input');
                let currentValue = parseInt(quantityInput.value);
                if (target.textContent === '+') {
                    quantityInput.value = currentValue + 1;
                } else if (currentValue > 1) {
                    quantityInput.value = currentValue - 1;
                }
            }

            if (target.classList.contains('remove-item')) {
                cartItem.remove();
            }

            updateCartTotal();
        });

        // TÍNH TỔNG TIỀN LẦN ĐẦU KHI TẢI TRANG
        updateCartTotal();
    });