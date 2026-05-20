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
            vapidKey: "BLyYoiyoTXoSb4l5REnZHxx0Fo_UH14WKdnx-URuKjmm8ryH6d7__ngrWfkq6PkFzzHfeMIBc15OLeJLfnp2VE4"
        });
        return token;
    }
    return null;
}