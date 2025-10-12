// wwwroot/js/site.js

document.addEventListener('DOMContentLoaded', function () {
    const chatbotButton = document.getElementById('chatbot-button');
    const chatbox = document.getElementById('chatbox');
    const closeChatboxBtn = document.getElementById('close-chatbox-btn');
    const chatForm = document.getElementById('chat-form');
    const chatInput = document.getElementById('chat-input');
    const chatboxBody = document.getElementById('chatbox-body');

    // Hiện/ẩn cửa sổ chat
    chatbotButton.addEventListener('click', () => {
        chatbox.style.display = 'flex';
    });

    closeChatboxBtn.addEventListener('click', () => {
        chatbox.style.display = 'none';
    });

    // Xử lý gửi tin nhắn
    chatForm.addEventListener('submit', function (e) {
        e.preventDefault(); // Ngăn form submit lại trang

        const userMessageText = chatInput.value.trim();
        if (userMessageText === '') return;

        // Hiển thị tin nhắn của người dùng
        appendMessage('user', userMessageText);
        chatInput.value = '';

        // Gửi tin nhắn đến Controller
        fetch('/Chatbot/SendMessage', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ text: userMessageText }),
        })
        .then(response => response.json())
        .then(data => {
            // Hiển thị tin nhắn trả lời của bot
            appendMessage('bot', data.response);
        })
        .catch(error => {
            console.error('Error:', error);
            appendMessage('bot', 'Xin lỗi, đã có lỗi xảy ra.');
        });
    });

    // Hàm để thêm tin nhắn vào cửa sổ chat
    function appendMessage(sender, text) {
        const messageDiv = document.createElement('div');
        messageDiv.classList.add('chat-message', sender);
        messageDiv.textContent = text;
        chatboxBody.appendChild(messageDiv);

        // Tự động cuộn xuống tin nhắn mới nhất
        chatboxBody.scrollTop = chatboxBody.scrollHeight;
    }
});