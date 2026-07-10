document.addEventListener("DOMContentLoaded", function () {
    const introScreen = document.getElementById('intro-screen');
    const authScreen = document.getElementById('auth-screen');

    introScreen.addEventListener('click', function () {
        // إضافة كلاس الإخفاء للشاشة الافتتاحية
        introScreen.classList.add('hidden');

        // الانتظار لحد ما الأنيميشن يخلص بعدين نشيلها من الـ DOM ونظهر الفورم
        setTimeout(() => {
            introScreen.style.display = 'none';

            authScreen.classList.remove('hidden');
            authScreen.style.position = 'relative'; // عشان ترجع لمكانها الطبيعي في الشاشة
        }, 800); // الرقم ده مطابق لزمن الـ transition في الـ CSS
    });
});