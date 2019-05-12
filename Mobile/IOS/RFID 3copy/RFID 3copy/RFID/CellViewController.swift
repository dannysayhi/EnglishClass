//
//  CellViewController.swift
//  RFID
//
//  Created by 吳貫瑋 on 2018/6/25.
//  Copyright © 2018年 ITRI. All rights reserved.
//

import UIKit

class CellViewController: UIViewController, UITableViewDataSource, UITableViewDelegate {
    
    @IBOutlet var tableView: UITableView!
    
    var times = ["107,11,11","107,06,23","107,06,09","107,07,08","107,08,07"]
    var receivers = ["Mark","Dean","Danny","Danel","LienWu"]
    var contains = ["Mobility-Aware","Traffic Control","Campus Care","Travel Time","Internet of Things"]
    var delivers = ["LienWu","LienWu","LienWu","LienWu","LienWu"]
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        // Do any additional setup after loading the view.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return 5
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = self.tableView.dequeueReusableCell(withIdentifier: "cell", for: indexPath) as! CustomCell
        
        cell.time.text = times[indexPath.row]
        cell.receiver.text = receivers[indexPath.row]
        cell.contain.text = contains[indexPath.row]
        cell.deliver.text = delivers[indexPath.row]
        
        return cell
    }

}
