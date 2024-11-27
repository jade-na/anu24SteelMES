﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using ReaLTaiizor.Forms;

namespace Project_SteelMES
{
    public partial class FactoryRegister : LostForm
    {
        // Oracle 연결 문자열
        private string connectionString = "User Id=scott;Password=tiger;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));";

        public FactoryRegister()
        {
            InitializeComponent();

            // Oracle 데이터를 바로 로드
            LoadFactoryDataFromOracle();
            
        }
        
        
        //오라클DB연동해오기
        private void LoadFactoryDataFromOracle()
        {
            try
            {
                // Oracle 연결
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    // SQL 쿼리
                    string query = "SELECT FACID AS 공장ID,FACNAME AS 공장이름, LOCATION AS 공장위치 FROM FACTORY";

                    // 데이터 어댑터와 데이터 테이블 생성
                    using (OracleDataAdapter adapter = new OracleDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // DataGridView에 데이터 바인딩
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                // 오류 메시지 표시
                MessageBox.Show($"데이터를 불러오는 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Lost6_Load(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e) //추가 버튼
        {
            FactoryRegister2 material2 = new FactoryRegister2(this);
            material2.StartPosition = FormStartPosition.Manual; // 위치를 수동으로 지정
            material2.Location = new Point(1000, 220);
            material2.Show();
        }

        private void button6_Click(object sender, EventArgs e) //설정 아이콘 버튼
        {
            
        }

        

        // Material2에서 호출할 행 추가 메서드
        public void AddRowToDataGridView(string text1, string text2)
        {
            dataGridView1.Rows.Add(text1, text2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Monitoring lost = new Monitoring();
            lost.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DefectRecord lost2 = new DefectRecord();
            lost2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Definition metro = new Definition();
            metro.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
