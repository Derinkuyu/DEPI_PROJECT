importScripts('https://www.gstatic.com/firebasejs/10.0.0/firebase-app-compat.js');
importScripts('https://www.gstatic.com/firebasejs/10.0.0/firebase-messaging-compat.js');

firebase.initializeApp({
    apiKey: "AIzaSyBcF_pmhpER7CasmoUA6mUAWHkjUPDkndk",
    authDomain: "stumap-85c52.firebaseapp.com",
    projectId: "stumap-85c52",
    storageBucket: "stumap-85c52.firebasestorage.app",
    messagingSenderId: "451154441133",
    appId: "1:451154441133:web:c8c3c448c42412cd136724"
});

const messaging = firebase.messaging();

// works in the background when the app is closed
messaging.onBackgroundMessage((payload) => {
    self.registration.showNotification(payload.notification.title, {
        body: payload.notification.body,
        icon: '/icon.png'
    });
});