import { initializeApp } from "https://www.gstatic.com/firebasejs/10.0.0/firebase-app.js";
import { getMessaging, getToken } from "https://www.gstatic.com/firebasejs/10.0.0/firebase-messaging.js";

const app = initializeApp({
    apiKey: "AIzaSyBcF_pmhpER7CasmoUA6mUAWHkjUPDkndk",
    authDomain: "stumap-85c52.firebaseapp.com",
    projectId: "stumap-85c52",
    storageBucket: "stumap-85c52.firebasestorage.app",
    messagingSenderId: "451154441133",
    appId: "1:451154441133:web:c8c3c448c42412cd136724"
});

const messaging = getMessaging(app);

export async function getDeviceToken() {
    const permission = await Notification.requestPermission();
    if (permission === "granted") {
        const token = await getToken(messaging, {
            vapidKey: "BAw9XLvqV2ElvZeJnvlzYYQ0IForA7ANo5Qz2gDGzbFfRbwEqXCH3VvlFsX7_67dWLs8vX8iH9IO-xnl554OSrM"
        });
        return token;
    }
    return null;
}