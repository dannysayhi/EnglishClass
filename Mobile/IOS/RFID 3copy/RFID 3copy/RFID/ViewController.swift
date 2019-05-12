//
//  ViewController.swift
//  RFID
//
//  Created by 吳貫瑋 on 2018/6/6.
//  Copyright © 2018年 ITRI. All rights reserved.
//

import UIKit

class ViewController: UIViewController, UIPickerViewDelegate, UIPickerViewDataSource, UITextFieldDelegate {
    
  
    @IBOutlet weak var textBox1: UITextField!
    @IBOutlet weak var textBox2: UITextField!
    
    @IBOutlet weak var dropDown1: UIPickerView!
    @IBOutlet weak var dropDown2: UIPickerView!
    
    //create list
    var list = ["Group 1", "Group 2", "Group 3", "All", "Personal"]
    var message = ["Message 1", "Message 2"]
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    
    public func numberOfComponents(in pickerView: UIPickerView) -> Int{
        return 1
        
    }
    
    public func pickerView(_ pickerView: UIPickerView, numberOfRowsInComponent component: Int) -> Int{
        
        var countrows = 0
        
        if pickerView == dropDown1 {
            
            countrows = self.list.count
            
        }else if pickerView == dropDown2{
            
            countrows = self.message.count
        }
        
        return countrows
        
    }
    
    func pickerView(_ pickerView: UIPickerView, titleForRow row: Int, forComponent component: Int) -> String? {
        
        if pickerView == dropDown1{
            self.view.endEditing(true)
            return list[row]
        }else if pickerView == dropDown2{
            self.view.endEditing(true)
            return message[row]
        }
        
        return ""
        
    }
    
    func pickerView(_ pickerView: UIPickerView, didSelectRow row: Int, inComponent component: Int) {
        
        if pickerView == dropDown1{
        
            self.textBox1.text = self.list[row]
            self.dropDown1.isHidden = true
            
        }else if pickerView == dropDown2{
            
            self.textBox2.text = self.message[row]
            self.dropDown2.isHidden = true
            
        }
        
    }
    
    func textFieldDidBeginEditing(_ textField: UITextField) {
        
        if textField == self.textBox1 {
            self.dropDown1.isHidden = false
            //if you dont want the users to se the keyboard type:
            
            textField.endEditing(true)
        }else if textField == self.textBox2{
            self.dropDown2.isHidden = false
        }
        
    }
}
