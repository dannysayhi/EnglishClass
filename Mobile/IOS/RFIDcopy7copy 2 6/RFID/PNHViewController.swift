//
//  PNHViewController.swift
//  RFID
//
//  Created by 吳貫瑋 on 2018/6/8.
//  Copyright © 2018年 ITRI. All rights reserved.
//

import UIKit
import Firebase
import FirebaseDatabase

class PNHViewController: UIViewController, UICollectionGridViewSortDelegate {
    var _identity: String?
    var gridViewController: UICollectionGridViewController!
    override func viewDidLoad() {
        super.viewDidLoad()
        UIApplication.shared.applicationIconBadgeNumber = 0
        var user = _identity as? String ?? ""
        var msg_list = Array<String>()
        gridViewController = UICollectionGridViewController()
        gridViewController.setColumns(columns: ["時間","對象", "內容", "發送者"])
        var ref: DatabaseReference!
        ref = Database.database().reference()
        ref.child("User").child(user).observeSingleEvent(of: .value, with: { (snapshot) in
            // Get user value
            let value = snapshot.value as? NSDictionary
            let permission = value?["Permission"] as? String ?? ""
            print(permission)
            var msgs = value?["Receives"] as? NSArray
            if permission == "toHome" {
                    msgs = value?["Sent"] as? NSArray
            }
            if msgs != nil {
                for msg in msgs!.reversed() {
                    let message = msg as? NSDictionary
                    let time = message?["time"] as? String ?? ""
                    let to = message?["to"] as? String ?? ""
                    let sender = message?["sender"] as? String ?? ""
                    let content = message?["content"] as? String ?? ""
                    self.gridViewController.addRow(row: [time, to, content, sender])
                }
            }
                        // ...
        }) { (error) in
            print(error.localizedDescription)
        }
        
        gridViewController.sortDelegate = self
        view.addSubview(gridViewController.view)
    }
    
    override func viewDidLayoutSubviews() {
        gridViewController.view.frame = CGRect(x:0, y:64, width:view.frame.width,
                                               height:view.frame.height-64)
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    
    //表格排序函数
    func sort(colIndex: Int, asc: Bool, rows: [[Any]]) -> [[Any]] {
        let sortedRows = rows.sorted { (firstRow: [Any], secondRow: [Any])
            -> Bool in
            let firstRowValue = firstRow[colIndex] as! String
            let secondRowValue = secondRow[colIndex] as! String
            if Int(firstRowValue) != nil && Int(secondRowValue) != nil{
                if colIndex == 0 || colIndex == 1 {
                    //首例、姓名使用字典排序法
                        if asc {
                            return firstRowValue < secondRowValue
                        }
                        return firstRowValue > secondRowValue
                    } else if colIndex == 2 || colIndex == 3 {
                        //中间两列使用数字排序
                    
                            if asc {
                                    return Int(firstRowValue)! < Int(secondRowValue)!
                            }
                            return Int(firstRowValue)! > Int(secondRowValue)!
        //                }
                    }
                    //最后一列数据先去掉百分号，再转成数字比较
                    let firstRowValuePercent = Int(String(firstRowValue[firstRowValue.index(before: firstRowValue.endIndex)]))!
                    let secondRowValuePercent = Int(String(secondRowValue[secondRowValue.index(before: secondRowValue.endIndex)]))!
                    if asc {
                        return firstRowValuePercent < secondRowValuePercent
                    }
                    return firstRowValuePercent > secondRowValuePercent
                }
            return true
        }
        return sortedRows
    }
}
