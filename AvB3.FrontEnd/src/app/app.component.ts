import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  public form: UntypedFormGroup;

  public resultado: any;

  constructor(public http: HttpClient, formBuilder: UntypedFormBuilder) {
    this.form = formBuilder.group({
      valorMonetario: ['', [Validators.required]],
      prazo: ['', [Validators.required,Validators.min(2)]]
    })


  }

  title = 'AvB3.FrontEnd';

  submit(){
    this.http.post('/calculocdb',
    {
      valorMonetario: parseInt(this.form.value.valorMonetario),
      prazo: parseInt(this.form.value.prazo)
    }).subscribe((result: any) => {
      this.resultado = result;
    })
  }

  clear(){
    this.form.reset();
    this.resultado = {};
  }

  public get valorInvestido(): number {
    return parseFloat(this.form.get('valorMonetario')?.value);
  }
}
