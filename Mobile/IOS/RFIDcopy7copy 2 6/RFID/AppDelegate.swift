import UIKit
import FirebaseCore
import FirebaseMessaging
import FirebaseInstanceID
import FirebaseDatabase
import UserNotifications

@UIApplicationMain
class AppDelegate: UIResponder, UIApplicationDelegate, MessagingDelegate, UNUserNotificationCenterDelegate {
    
    var window: UIWindow?
    var identity: String?
    var username: String?
    var permission: String?
    var student_ID: String?
    var student_name: String?
    var groups = [String]()
    var message = [String]()
    //    var msg_dict = ["Message 1": "小孩生病", "Message 2": "小孩未出席"]
    var msg_dict = Dictionary<String, String>()
    
    var current_version = 0.16
    
    func application(_ application: UIApplication, didFinishLaunchingWithOptions launchOptions: [UIApplication.LaunchOptionsKey: Any]?) -> Bool {
        // Override point for customization after application launch.
        UNUserNotificationCenter.current().requestAuthorization(options: [.alert, .sound, .badge]) { (isGranted, err) in
            if err != nil {
                //Something bad happend
            } else {
                UNUserNotificationCenter.current().delegate = self
                Messaging.messaging().delegate = self
                DispatchQueue.main.async {
                    UIApplication.shared.registerForRemoteNotifications()
                }
            }
        }
        FirebaseApp.configure()
        
//        UserDefaults.standard.set(0.12, forKey: "appVersion")
        let appVersion = UserDefaults.standard.double(forKey: "appVersion")
        print(current_version)
        print(appVersion)
        if current_version > appVersion {
            UserDefaults.standard.set(false, forKey: "isUserLoggedIn")
            UserDefaults.standard.set("", forKey: "Account")
            UserDefaults.standard.set("", forKey: "Password")
            UserDefaults.standard.set("", forKey: "Username")
            UserDefaults.standard.set("", forKey: "Permission")
            UserDefaults.standard.set("", forKey: "StudentName")
            UserDefaults.standard.set("", forKey: "ID")
            UserDefaults.standard.set(current_version, forKey: "appVersion")
            UserDefaults.standard.set([], forKey: "SubscribedDict")
            UserDefaults.standard.set([], forKey: "SubscribedTopics")
            UserDefaults.standard.synchronize()
            Messaging.messaging().unsubscribe(fromTopic: "BroadcastTopic")
//            Messaging.messaging().unsubscribe(fromTopic: "ManagerTopic")
            var ref: DatabaseReference!
            ref = Database.database().reference()
            ref.child("Topic").observeSingleEvent(of: .value, with: { (snapshot) in
                for rest in snapshot.children.allObjects as! [DataSnapshot]{
                    Messaging.messaging().unsubscribe(fromTopic: rest.key)
                // ...
                }
            })
        }
        
        
        return true
    }
    
    func ConnectToFCM() {
        Messaging.messaging().shouldEstablishDirectChannel = true
        Messaging.messaging().subscribe(toTopic: "BroadcastTopic")
        Messaging.messaging().subscribe(toTopic: "AllAdmin")
        if let token = InstanceID.instanceID().token() {
//            UIApplication.shared.applicationIconBadgeNumber = 0
            print("DCS: " + token)
        }
        
    }
    
    func applicationWillResignActive(_ application: UIApplication) {
    }
    
    func applicationDidEnterBackground(_ application: UIApplication) {
        Messaging.messaging().shouldEstablishDirectChannel = false
    }
    
    func applicationWillEnterForeground(_ application: UIApplication) {
    }
    
    func applicationDidBecomeActive(_ application: UIApplication) {
        ConnectToFCM()
    }
    
    func applicationWillTerminate(_ application: UIApplication) {
    }
    
    func messaging(_ messaging: Messaging, didRefreshRegistrationToken fcmToken: String) {
        ConnectToFCM()
    }
    
    func userNotificationCenter(_ center: UNUserNotificationCenter, willPresent notification: UNNotification, withCompletionHandler completionHandler: @escaping (UNNotificationPresentationOptions) -> Void) {
        UIApplication.shared.applicationIconBadgeNumber += 1
        NotificationCenter.default.post(name: NSNotification.Name(rawValue: "com.DouglasDevlops.BadgeWasUpdated"), object: nil)
        completionHandler([.badge, .sound, .alert])
    }
}


