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

class Login: UIViewController {
    @IBOutlet var loginview: UIView!
    @IBOutlet weak var navibar: UINavigationItem!
    @IBOutlet weak var acc: UITextField!
    @IBOutlet weak var passwd: UITextField!
    @IBOutlet weak var info: UILabel!
    var identity: String?
    var username: String?
    var permission: String?
    var student_ID: String?
    var student_name: String?
    var groups = [String]()
    var message = [String]()
    var subscribes = [String]()
    var subscribe_dict = Dictionary<String, String>()
    //    var msg_dict = ["Message 1": "小孩生病", "Message 2": "小孩未出席"]
    var msg_dict = Dictionary<String, String>()
    override func viewDidLoad() {
        super.viewDidLoad()
        loginview.isHidden = true
        navigationController?.setNavigationBarHidden(true, animated: true)
        var ref: DatabaseReference!
        ref = Database.database().reference()
        ref.child("Course").observeSingleEvent(of: .value, with: { (snapshot) in
            for rest in snapshot.children.allObjects as! [DataSnapshot]{
                var value = rest.value as? NSDictionary
                var course_name = value?["Course_Name"] as? String ?? ""
                self.groups.append(course_name)
            }
            self.groups.append("BroadcastTopic")
            UserDefaults.standard.set(self.groups, forKey: "Groups")
        })

        ref.child("Messages").observeSingleEvent(of: .value, with: { (snapshot) in
            for rest in snapshot.children.allObjects as! [DataSnapshot]{
                var value = rest.value as? NSDictionary
                var msgname = value?["MsgName"] as? String ?? ""
                var msgcontent = value?["Msg"] as? String ?? ""
                self.message.append(msgname)
                self.msg_dict.updateValue(msgcontent, forKey: msgname)
            }
            UserDefaults.standard.set(self.message, forKey: "Message")
            UserDefaults.standard.set(self.msg_dict, forKey: "MsgDict")
            UserDefaults.standard.synchronize()
            let userLoginStatus = UserDefaults.standard.bool(forKey: "isUserLoggedIn")
            let userAccount = UserDefaults.standard.string(forKey: "Account")
            let userName = UserDefaults.standard.string(forKey: "Username")
            let Permission = UserDefaults.standard.string(forKey: "Permission")
            let Message = UserDefaults.standard.array(forKey: "Message")
            let MsgDict = UserDefaults.standard.dictionary(forKey: "MsgDict")
            let Groups = UserDefaults.standard.array(forKey: "Groups")
            let Subscibed = UserDefaults.standard.array(forKey: "SubscribedTopics")
//            if UserDefaults.standard.dictionary(forKey: "SubscribedDict") as! [String : String] != nil{
//                self.subscribe_dict = UserDefaults.standard.dictionary(forKey: "SubscribedDict") as! [String : String]
//            }
            
            
            if(userLoginStatus){
                self.identity = userAccount as? String ?? ""
                self.username = userName as? String ?? ""
                self.permission = Permission as? String ?? ""
                self.subscribes = Subscibed as? Array ?? [""]
                self.subscribe_dict = UserDefaults.standard.dictionary(forKey: "SubscribedDict") as! [String : String]
                //self.message = Message as? Array ?? [""]
                //self.msg_dict = MsgDict as? Dictionary ?? ["": ""]
                //self.groups = Groups as? Array ?? [""]
                if self.permission! == "toParent"{
                    self.student_name = UserDefaults.standard.string(forKey: "StudentName")
                }
                self.loginview.isHidden = false
                self.performSegue(withIdentifier: self.permission!, sender: self)
            }
            else{
                self.loginview.isHidden = false
                self.navigationController?.setNavigationBarHidden(false, animated: false)
            }
        })
       
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        self.view.endEditing(true);
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        let homeVC = segue.destination as! ViewController
        homeVC._identity = identity
        homeVC._permission = segue.identifier
        homeVC._username = username
        homeVC._studentname = student_name
        homeVC.message = message
        homeVC.msg_dict = msg_dict
        homeVC.list = groups
        homeVC._studentID = student_ID
        homeVC.subscribed_topics = subscribes
        homeVC.subscribe_dict = subscribe_dict
    }
//    override func viewDidAppear(_ animated: Bool) {
//        self.performSegue(withIdentifier: "loginview", sender: self)
//    }
    
    func delayWithSeconds(_ seconds: Double, completion: @escaping () -> ()) {
        DispatchQueue.main.asyncAfter(deadline: .now() + seconds) {
            completion()
        }
    }

    
    @IBAction func login(_ sender: UIButton) {
        if acc.text == "" {
            self.info.text = "登入失敗!"
            self.info.textColor = UIColor.red
        }
        else {
            var ref: DatabaseReference!
            ref = Database.database().reference()
            ref.child("User").child(acc.text!).observeSingleEvent(of: .value, with: { (snapshot) in
                // Get user value
                let value = snapshot.value as? NSDictionary
                let phone = value?["Phone"] as? String ?? ""
                if phone != "" {
                    let password = value?["Password"] as? String ?? ""
                    if password != "" && password == self.passwd.text! {
                        self.info.text = ""
                        let permission = value?["Permission"] as? String ?? ""
                        self.identity = self.acc.text!
                        self.username = value?["Username"] as? String ?? ""
                        self.subscribes = value?["SubscribeTopics"] as! [String]
                        var index = 0
                        for var subscribe in self.subscribes{
                            self.subscribe_dict[subscribe] = String(index)
                            index = index + 1
                        }
                        UserDefaults.standard.set(true, forKey: "isUserLoggedIn")
                        UserDefaults.standard.set(self.identity!, forKey: "Account")
                        UserDefaults.standard.set(self.passwd.text!, forKey: "Password")
                        UserDefaults.standard.set(self.username!, forKey: "Username")
                        UserDefaults.standard.set(permission, forKey: "Permission")
                        UserDefaults.standard.set(self.subscribes, forKey: "SubscribedTopics")
                        UserDefaults.standard.set(self.subscribe_dict, forKey: "SubscribedDict")

                        if permission == "toParent" {
                            self.student_ID = value?["ID"] as? String ?? ""
                            ref.child("Student").child(self.student_ID!).observeSingleEvent(of: .value, with: { (snapshot) in
                                let val = snapshot.value as? NSDictionary
                                self.student_name = val?["TwName"] as? String ?? ""
                                UserDefaults.standard.set(self.student_name, forKey: "StudentName")
                                UserDefaults.standard.set(self.student_ID, forKey: "StudentID")
                                UserDefaults.standard.synchronize()
                                self.performSegue(withIdentifier: permission, sender: self)
//                                    print(self.student_name as? String ?? "")
                            })
                        }
                        else if permission == "toHome" {
                            UserDefaults.standard.synchronize()
                            self.performSegue(withIdentifier: permission, sender: self)
                        }
                        else {
                            UserDefaults.standard.set(false, forKey: "isUserLoggedIn")
                            UserDefaults.standard.set("", forKey: "Account")
                            UserDefaults.standard.set("", forKey: "Password")
                            UserDefaults.standard.set("", forKey: "Username")
                            UserDefaults.standard.set("", forKey: "Permission")
                            UserDefaults.standard.synchronize()
                            self.info.text = "登入失敗!帳號資訊不全!"
                            self.info.textColor = UIColor.red
                        }
//                            ref.child("User").child(self.acc.text!).child("Login").setValue("True")
                    }
                    else {
                        self.info.text = "登入失敗!"
                        self.info.textColor = UIColor.red
                    }
                }
                    else{
                        self.info.text = "登入失敗!"
                        self.info.textColor = UIColor.red
                    }
                    // ...
                }) { (error) in
                    print(error.localizedDescription)
                }
        }
    }
 }
