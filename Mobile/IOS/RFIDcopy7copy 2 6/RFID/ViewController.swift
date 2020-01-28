//
//  ViewController.swift
//  RFID
//
//  Created by 吳貫瑋 on 2018/6/6.
//  Copyright © 2018年 ITRI. All rights reserved.
//

import UIKit
import UserNotifications
import Firebase
import FirebaseDatabase
import Foundation

class ViewController: UIViewController, UIPickerViewDelegate, UIPickerViewDataSource, UITextFieldDelegate {
    var _identity: String?
    var _permission: String?
    var _username: String?
    var _studentname: String?
    var _studentID: String?
    var times = [String]()
    var receivers = [String]()
    var contains = [String]()
    var delivers = [String]()

    
    @IBOutlet weak var Parent_title: UINavigationItem!
    @IBOutlet weak var Admin_title: UINavigationItem!
    @IBOutlet weak var send: UITextField!
    @IBOutlet weak var textBox1: UITextField!
    @IBOutlet weak var textBox2: UITextField!
    @IBOutlet weak var textBox3: UITextField!
    @IBOutlet weak var textView2: UITextView!
    @IBOutlet weak var dropDown1: UIPickerView!
    @IBOutlet weak var dropDown2: UIPickerView!
    @IBOutlet weak var dropDown3: UIPickerView!
    @IBAction func subscribeCourse(_ sender: AnyObject) {
        if textBox3.text! != ""{
            var ref: DatabaseReference!
            ref = Database.database().reference()
            Messaging.messaging().shouldEstablishDirectChannel = true
            Messaging.messaging().subscribe(toTopic: textBox3.text!)
            ref.child("User").child(self._identity as? String ?? "").child("SubscribeTopics").observeSingleEvent(of: .value, with: { (snapshot) in
                    var subscribe_count = snapshot.childrenCount
                    var subscribe_list = snapshot.value as? NSArray ?? []
                if !subscribe_list.contains(self.textBox3.text!){
                      ref?.child("User").child(self._identity as? String ?? "").child("SubscribeTopics").child(String(subscribe_count)).setValue(self.textBox3.text!)
                    self.delayWithSeconds(0) {
                        //Do something
                        var msg = "訂閱" + self.textBox3.text! + "成功!"
                        self.showToast(message: msg as! String)
                        self.subscribe_dict[self.textBox3.text!] = String(subscribe_count)
                        self.subscribed_topics.append(self.textBox3.text!)
                        UserDefaults.standard.set(self.subscribed_topics, forKey: "SubscribedTopics")
                        UserDefaults.standard.set(self.subscribe_dict, forKey: "SubscribedDict")
                        UserDefaults.standard.synchronize()
                    }
                }
                else{
                    self.delayWithSeconds(0) {
                        //Do something
                        self.showToast(message: "此主題已被訂閱" as! String)
                    }
                }
            })
        }
        else{
            delayWithSeconds(0) {
                //Do something
                self.showToast(message: "沒有選擇主題" as! String)
            }
        }
    }
    @IBAction func unsubscribeTopic(_ sender: AnyObject) {
        if textBox3.text! != ""{
            
            var ref: DatabaseReference!
            ref = Database.database().reference()
            Messaging.messaging().shouldEstablishDirectChannel = true
            print(subscribe_dict)
            if subscribe_dict[self.textBox3.text!] != nil {
                Messaging.messaging().unsubscribe(fromTopic: textBox3.text!)
                ref.child("User").child(self._identity as? String ?? "").child("SubscribeTopics").child(subscribe_dict[textBox3.text!]!).removeValue()
                subscribed_topics.remove(at: Int(subscribe_dict[textBox3.text!]!) ?? 0)
                var new_subscribe_count = 0
                for subscribed in subscribed_topics{
                    subscribe_dict[subscribed] = String(new_subscribe_count)
                    new_subscribe_count = new_subscribe_count + 1
                }
                subscribe_dict.removeValue(forKey: textBox3.text!)
                UserDefaults.standard.set(subscribed_topics, forKey: "SubscribedTopics")
                UserDefaults.standard.set(subscribe_dict, forKey: "SubscribedDict")
                UserDefaults.standard.synchronize()
                ref?.child("User").child(self._identity as? String ?? "").child("SubscribeTopics").setValue(subscribed_topics)
                self.delayWithSeconds(0) {
                    //Do something
                    var msg = "取消訂閱" + self.textBox3.text! + "成功!"
                    self.showToast(message: msg as! String)
                }
                
            }else{
                self.delayWithSeconds(0) {
                    //Do something
                    self.showToast(message: "此主題未被訂閱" as! String)
                }
            }
        }
        else{
            delayWithSeconds(0) {
                //Do something
                self.showToast(message: "沒有選擇主題" as! String)
            }
        }
    }
    @IBAction func createNotification(_ sender: AnyObject) {
        
        let now: Date = Date()
        let dateFormat: DateFormatter = DateFormatter()
        dateFormat.dateFormat = "yyyy-MM-dd HH:mm:ss"
        let dateString: String = dateFormat.string(from: now)
        var title: String?
        var msg: String?
        var body: String?
        var ref: DatabaseReference!
        ref = Database.database().reference()
        var valid_input = false
        var topic: String?
        let controller = UIAlertController(title: "怎麼可以忘了!", message: "忘了輸入女朋友的名字", preferredStyle: .alert)
        let okAction = UIAlertAction(title: "OK", style: .default, handler: nil)
        controller.addAction(okAction)
        
        if _permission == "toHome" {
            if textView2.text != "" {
                title = "推播通知"
                body = textView2.text
                msg = "推播發送成功"
                valid_input = true
                let topic_prefix = "/topics/"
                var title = "BroadcastTopic"
                if self.textBox1.text != ""{
                    title = self.textBox1.text!
                }
                topic = topic_prefix + title

//                print(topic)
                ref.child("User").child(self._identity as? String ?? "").child("Sent").observeSingleEvent(of: .value, with: { (snapshot) in
                    var sent_count = snapshot.childrenCount
                    sent_count = sent_count + 1
                    ref?.child("User").child(self._identity as? String ?? "").child("Sent").child(String(sent_count)).updateChildValues(["content": body, "sender": self._username as? String ?? "", "to": title, "time": dateString])
                })
                
                ref.child("User").observeSingleEvent(of: .value, with: { (snapshot) in
                    for rest in snapshot.children.allObjects as! [DataSnapshot]{
                        var value = rest.value as? NSDictionary
                        var admin_name = value?["Username"] as? String ?? ""
                        var phone = value?["Phone"] as? String ?? ""
                        
                        var receives = value?["Receives"] as? NSArray
                        var receive_count = receives?.count as? Int ?? 0
                        //receive_count = receive_count + 1
                        
                        if phone != "" && admin_name != "" {
                            ref?.child("User").child(phone).child("Receives").child(String(receive_count)).updateChildValues(["content": body, "sender": self._username as? String ?? "", "to": admin_name, "time": dateString])
                            
                        }
                    }
                })
            }
            
        }
        else if _permission == "toParent" {
            valid_input = true
            title = "接送提醒"
            body = "該接送學生囉"
            topic = "/topics/AllAdmin"
            msg = "接送通知發送成功"
            ref.child("Pickup").observeSingleEvent(of: .value, with: { (snapshot) in
                
                var pick_count = snapshot.childrenCount
                pick_count = pick_count + 1
                ref?.child("Pickup").child(String(pick_count)).updateChildValues(["ID":self._studentID as? String ?? "", "phone": self._identity ?? "",  "name":self._studentname as? String ?? ""])
              
            })
            
            ref.child("User").observeSingleEvent(of: .value, with: { (snapshot) in
                for rest in snapshot.children.allObjects as! [DataSnapshot]{
                    var value = rest.value as? NSDictionary
                    var admin_name = value?["Username"] as? String ?? ""
                    var phone = value?["Phone"] as? String ?? ""
                    var permission = value?["Permission"] as? String ?? ""
                    if phone != "" && admin_name != "" && permission != "" {
                        if permission == "toHome" {
                            ref.child("User").child(phone).child("Receives").observeSingleEvent(of: .value, with: { (snapshot) in
                                
                                var receive_count = snapshot.childrenCount
                                receive_count = receive_count + 1
                            ref?.child("User").child(phone).child("Receives").child(String(receive_count)).updateChildValues(["content": body, "sender": self._username as? String ?? "", "to": admin_name, "time": dateString])
                            })
                            ref.child("User").child(self._identity as? String ?? "").child("Sent").observeSingleEvent(of: .value, with: { (snapshot) in
                                
                                var sent_count = snapshot.childrenCount
                                sent_count = sent_count + 1
                                ref?.child("User").child(self._identity as? String ?? "").child("Sent").child(String(sent_count)).updateChildValues(["content": body, "sender": self._username as? String ?? "", "to": admin_name, "time": dateString])
                            })
                        }
                    }
                   
                }
            })
        }
        if valid_input == true {
            print(topic as! NSString)
            var url : String = "https://fcm.googleapis.com/fcm/send"
            var request : NSMutableURLRequest = NSMutableURLRequest()
            let notification: NSDictionary = [
                "body": body,
                "title": title,
//                "badge": 1,
            ]
            let post_data: [NSString: Any] = [
                "project_id": "danny9428" as! NSString,
                "to": topic as! NSString,
                "notification": notification
            ]
            print(JSONSerialization.isValidJSONObject(post_data))
            let ns_data = post_data as NSDictionary
            print(type(of:ns_data))
            let json_data = try! JSONSerialization.data(withJSONObject: ns_data, options: [])
            request.url = URL(string: url)
            request.httpMethod = "POST"
            request.addValue("application/json", forHTTPHeaderField: "Content-Type")
        request.addValue("key=AAAArFeGkA0:APA91bGYtYlAGITmCBZUBMbWMDDsa7a4D2ZYEGYmPpG26D1F24UHMut28WApKSAQcPSe1fGDMp5gCrXUcqSIuTlqI2DSFwooDo4ddJfHIKmsEEgpdX5QikrdWweJMG3QMNdpN4N6jx_e", forHTTPHeaderField: "Authorization")
            request.httpBody = json_data
            NSURLConnection.sendAsynchronousRequest(request as URLRequest, queue: OperationQueue()) { (response: URLResponse!, data: Data!, error: Error!) in
                var error: AutoreleasingUnsafeMutablePointer<NSError>? = nil
                let jsonResult: NSDictionary! = try! JSONSerialization.jsonObject(with: data, options: JSONSerialization.ReadingOptions.mutableContainers) as? NSDictionary
                if (jsonResult != nil){
                    self.delayWithSeconds(0) {
                        //Do something
                        self.showToast(message: msg as! String)
                    }
                    print(jsonResult)
                } else {
                    
                }
            }
        }
        else {
            self.delayWithSeconds(0) {
                //Do something
                self.showToast(message: "訊息不得為空白" as! String)
            }
        }
    }
    

    var list = [String]()
    var message = [String]()
    var subscribe_topics = [String]()
    var subscribed_topics = [String]()
    var subscribe_dict = Dictionary<String, String>()
//    var msg_dict = ["Message 1": "小孩生病", "Message 2": "小孩未出席"]
    var msg_dict = Dictionary<String, String>()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        print("load view")
        navigationController?.setNavigationBarHidden(false, animated: false)
        Messaging.messaging().shouldEstablishDirectChannel = true
        Messaging.messaging().subscribe(toTopic: "BroadcastTopic")
        subscribe_topics.append("BroadcastTopic")
        if _permission == "toHome" {
            var manager = "管理者: "
            manager.append(_username as? String ?? "")
            Admin_title.title = manager
            Messaging.messaging().subscribe(toTopic: "AllAdmin")
            subscribe_topics.append("AllAdmin")
        }
        else if _permission == "toParent" {
            var parent = "家長: "
            parent.append(_username as? String ?? "")
            var student = "  學生: "
            student.append(_studentname as? String ?? "")
            parent.append(student)
            Parent_title.title = parent
            Messaging.messaging().subscribe(toTopic: "AllParents")
            subscribe_topics.append("AllParents")
        }
        var user = _identity as? String ?? ""
        var ref: DatabaseReference!
        ref = Database.database().reference()
        ref.child("User").child(user).observeSingleEvent(of: .value, with: { (snapshot) in
            // Get user value
            let value = snapshot.value as? NSDictionary
            let permission = value?["Permission"] as? String ?? ""
            var msgs = value?["CardMsgs"] as? NSArray
            var subscribe_count = 0
            ref.child("User").child(self._identity as? String ?? "").child("SubscribeTopics").observeSingleEvent(of: .value, with: { (snapshot) in
                for var topic in self.subscribe_topics{
                    ref?.child("User").child(self._identity as? String ?? "").child("SubscribeTopics").child(String(subscribe_count)).setValue(topic)
                    subscribe_count = subscribe_count + 1
                }
            })
            print(self.subscribed_topics)
            for subcribed in self.subscribed_topics{
                Messaging.messaging().subscribe(toTopic: subcribed)
            }
            if msgs != nil {
                for msg in msgs!.reversed() {
                    let messages = msg as? NSDictionary
                    let time = messages?["time"] as? String ?? ""
                    let title = messages?["title"] as? String ?? ""
                    let student = messages?["student"] as? String ?? ""
                    let content = messages?["content"] as? String ?? ""
                    self.times.append(time)
                    self.receivers.append(title)
                    self.contains.append(content)
                    self.delivers.append(student)
                }
            }
            // ...
        })
//        Back_title.title =
    }
    
    override func viewWillDisappear(_ animated: Bool)
    {
        super.viewWillDisappear(animated);
        if self.isMovingFromParentViewController
        {
            UserDefaults.standard.set(false, forKey: "isUserLoggedIn")
            UserDefaults.standard.set("", forKey: "Account")
            UserDefaults.standard.set("", forKey: "Password")
            UserDefaults.standard.set("", forKey: "Username")
            UserDefaults.standard.set("", forKey: "Permission")
            UserDefaults.standard.set("", forKey: "StudentName")
            UserDefaults.standard.set("", forKey: "ID")
            UserDefaults.standard.set([], forKey: "SubscribedDict")
            UserDefaults.standard.set([], forKey: "SubscribedTopics")
            UserDefaults.standard.synchronize()
            //            Messaging.messaging().unsubscribe(fromTopic: "ManagerTopic")
            var ref: DatabaseReference!
            ref = Database.database().reference()
            ref.child("User").child(self._identity as? String ?? "").child("SubscribeTopics").observeSingleEvent(of: .value, with: { (snapshot) in
                for rest in snapshot.children.allObjects as! [DataSnapshot]{
                    print(rest.value as! String)
                    Messaging.messaging().unsubscribe(fromTopic: rest.value as! String)
                    // ...
                }
            })
        }
        if self.isBeingDismissed
        {
            //Dismissed
        }
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        self.view.endEditing(true);
    }
    
    public func numberOfComponents(in pickerView: UIPickerView) -> Int{
        return 1
        
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if segue.identifier == "History_message" {
            let PNHVC = segue.destination as! PNHViewController
            PNHVC._identity = _identity as? String ?? ""
        }
        else {
             let PNHVC = segue.destination as! PHNCardController
             PNHVC._identity = _identity as? String ?? ""
        }
    }
    
    public func pickerView(_ pickerView: UIPickerView, numberOfRowsInComponent component: Int) -> Int{
        
        var countrows = 0
        if _permission == "toHome"{
            if pickerView == dropDown1{
                
                countrows = self.list.count
                
            }else if pickerView == dropDown2{
                
                countrows = self.message.count
            }
        }
        else{
            if pickerView == dropDown3{
                countrows = self.list.count
            }
        }
        
        return countrows
        
    }
    
    func pickerView(_ pickerView: UIPickerView, titleForRow row: Int, forComponent component: Int) -> String? {
        
        if _permission == "toHome"{
            if pickerView == dropDown1{
                self.view.endEditing(true)
                return list[row]
            }else if pickerView == dropDown2{
                self.view.endEditing(true)
                return message[row]
            }
        }else{
            if pickerView == dropDown3{
                self.view.endEditing(true)
                return list[row]
            }
        }
        
        return ""
        
    }
    
    func pickerView(_ pickerView: UIPickerView, didSelectRow row: Int, inComponent component: Int) {
        if _permission == "toHome"{
            if pickerView == dropDown1{
                self.textBox1.text = self.list[row]
                self.dropDown1.isHidden = true
                
            }else if pickerView == dropDown2{
                self.textBox2.text = self.message[row]
                self.textView2.text = self.msg_dict[self.message[row]]
                self.dropDown2.isHidden = true
                
            }
        }else{
            if pickerView == dropDown3{
                self.textBox3.text = self.list[row]
                self.dropDown3.isHidden = true
            }
        }
        
    }
    
    func textFieldDidBeginEditing(_ textField: UITextField) {
        if _permission == "toHome"{
            if textField == self.textBox1 {
                self.dropDown1.isHidden = false
                //if you dont want the users to se the keyboard type:
                textField.endEditing(true)
            }else if textField == self.textBox2{
                self.dropDown2.isHidden = false
            }
        }
        else{
            if textField == self.textBox3 {
                self.dropDown3.isHidden = false
                //if you dont want the users to se the keyboard type:
                textField.endEditing(true)
            }
        }
    }
    
    func delayWithSeconds(_ seconds: Double, completion: @escaping () -> ()) {
        DispatchQueue.main.asyncAfter(deadline: .now() + seconds) {
            completion()
        }
    }
}
extension ViewController{
    func showToast(message: String){
        let toastLabel = UILabel(frame: CGRect(x: self.view.frame.width/2-75, y: self.view.frame.height - 100, width: 150, height: 40))
        toastLabel.textAlignment = .center
        toastLabel.backgroundColor = UIColor.black.withAlphaComponent(0.6)
        toastLabel.textColor = UIColor.white
        toastLabel.alpha = 1.0
        toastLabel.layer.cornerRadius = 10
        toastLabel.clipsToBounds = true
        toastLabel.text = message
        self.view.addSubview(toastLabel)
        
        UIView.animate(withDuration: 4.0, delay: 1.0, options: .curveEaseInOut, animations: {
            toastLabel.alpha = 0.0
        }) { (isCompleted) in
            toastLabel.removeFromSuperview()
        }
    }
}
