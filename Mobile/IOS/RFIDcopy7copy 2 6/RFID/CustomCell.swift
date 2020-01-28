//
//  CustomCell.swift
//  RFID
//
//  Created by 吳貫瑋 on 2018/6/25.
//  Copyright © 2018年 ITRI. All rights reserved.
//

import UIKit

class CustomCell: UITableViewCell {

    @IBOutlet var time: UILabel!
    @IBOutlet var receiver: UILabel!
    @IBOutlet var contain: UILabel!
    @IBOutlet var deliver: UILabel!
    
    override func awakeFromNib() {
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }

}
