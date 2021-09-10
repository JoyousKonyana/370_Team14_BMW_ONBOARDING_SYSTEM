import { Component, VERSION ,ViewChild } from '@angular/core';

  export class CsvData {
    public Employee_ID: number;
  public Department_ID: number;
  public first_name: string; 
  public Middle_Name: string; 
  public Last_Name: string;  
  public Title: string; 
  public Gender_ID: string; 
  public ID_Number: string; 
  public Contact_Number: string; 
  public Job_Title: string; 
  public Address_ID: number; 
}

@Component({
  selector: 'my-app',
  templateUrl: './import_employee.component.html',
  styleUrls: [ './ss_administrator.component.css' ]
})
export class Import_EmployeeComponent  {

//   name = 'Angular ' + VERSION.major;
//   public records: any[] = [];
//   @ViewChild('csvReader') csvReader: any;
//   jsondatadisplay:any;

//   uploadListener($event: any): void {

//     let text = [];
//     let files = $event.srcElement.files;

//     if (this.isValidCSVFile(files[0])) {

//       let input = $event.target;
//       let reader = new FileReader();
//       reader.readAsText(input.files[0]);

//       reader.onload = () => {
//         let csvData = reader.result;
//         let csvRecordsArray = (<string>csvData).split(/\r\n|\n/);

//         let headersRow = this.getHeaderArray(csvRecordsArray);

//         this.records = this.getDataRecordsArrayFromCSVFile(csvRecordsArray, headersRow.length);
//       };

//       reader.onerror = function () {
//         console.log('error is occured while reading file!');
//       };

//     } else {
//       alert("Please import valid .csv file.");
//       this.fileReset();
//     }
//   }

//   getDataRecordsArrayFromCSVFile(csvRecordsArray: any, headerLength: any) {
//     let csvArr = [];

//     for (let i = 1; i < csvRecordsArray.length; i++) {
//       let curruntRecord = (<string>csvRecordsArray[i]).split(',');
//       if (curruntRecord.length == headerLength) {
//         let csvRecord: CsvData = new CsvData();

//         csvRecord.Employee_ID = curruntRecord[0].trim();
//         csvRecord.Department_ID = curruntRecord[1].trim();
//         csvRecord.first_name = curruntRecord[2].trim();
//         csvRecord.Middle_Name = curruntRecord[3].trim();

//         csvRecord.Title = curruntRecord[4].trim();
//         csvRecord.Gender_ID = curruntRecord[5].trim();
//         csvRecord.ID_Number = curruntRecord[6].trim();

//         csvRecord.Contact_Number = curruntRecord[7].trim();
//         csvRecord.Job_Title = curruntRecord[8].trim();
//         csvRecord.Address_ID = curruntRecord[9].trim();

//         csvArr.push(csvRecord);
//       }
//     }
//     return csvArr;
//   }

// //check etension
//   isValidCSVFile(file: any) {
//     return file.name.endsWith(".csv");
//   }

//   getHeaderArray(csvRecordsArr: any) {
//     let headers = (<string>csvRecordsArr[0]).split(',');
//     let headerArray = [];
//     for (let j = 0; j < headers.length; j++) {
//       headerArray.push(headers[j]);
//     }
//     return headerArray;
//   }

//   fileReset() {
//     this.csvReader.nativeElement.value = "";
//     this.records = [];
//     this.jsondatadisplay = '';
//   }

//   getJsonData(){
//     this.jsondatadisplay = JSON.stringify(this.records);
//   }


}
