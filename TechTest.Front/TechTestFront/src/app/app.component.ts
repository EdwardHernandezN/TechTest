import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  id= "";
  Code = "123";
  Name = "Producto NgModel";
  Status = 1;
  product = {id: "", Code: "123", Name: "Producto NgModel", Status: 1};
  title = 'TechTestFront';


  onSubmit(){}
}
