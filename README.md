# SQLlearn
学习SQL  
1.基础语言  
2.界面制作基本   

v1.1  
添加了从表中获得数据的增删改查  
使用dataGridView1_RowEnter获得焦点行  
 DataGridViewRow currentrow = dataGridView1.Rows[e.RowIndex]; 获得行数据  
 TBLClass model=  currentrow.DataBoundItem as TBLClass;  将类进行转换  
  确认是否删除信息的部分：  
                DialogResult result= MessageBox.Show("确定要删除吗？", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
           if (result == DialogResult.OK)  

  
登陆1    
界面的制作  
带参数的sql语句    
静态类成员    
