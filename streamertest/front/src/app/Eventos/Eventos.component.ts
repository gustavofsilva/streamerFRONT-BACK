import { templateJitUrl } from '@angular/compiler';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Course } from '../Models/Course';
import { Evento } from '../Models/Evento';
import { EventoService } from '../Services/evento.service';

@Component({
  selector: 'app-Eventos',
  templateUrl: './Eventos.component.html',
  styleUrls: ['./Eventos.component.scss']
})
export class EventosComponent implements OnInit {


  eventos: Evento[] = [];
  evento: Evento = new Evento();
  eventoId: Evento = new Evento();
  modoSalvar : string = '';
  registerForm : FormGroup | any;
  idForm: FormGroup | any;

  constructor(
    private eventoService: EventoService
    , private modalService: BsModalService    
    , private fb: FormBuilder
    
    ) {
      }

  ngOnInit() {
    this.getEventos();
    this.validation();
  }
  validation (){
    this.registerForm = this.fb.group ({
      name: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(150)]],
      why: ['', Validators.required],
      what: ['', Validators.required],
      whatWillWeDo: ['', Validators.required],
      image: ['', Validators.required],
      courseId: ['', Validators.required]

    });
  }
 

  salvarAlteracao(template : any) {
    if (this.registerForm.valid) {
      if (this.modoSalvar === 'post') {
        this.evento = Object
        .assign({ Course: this.evento.Course }, this.registerForm.value); 
        this.evento.courseId = 1;

        this.eventoService
        .postEvento(this.evento)
        .subscribe(
          () => {
            template.hide();
            this.getEventos();
          }
        );
        
      } else {
        this.evento = Object.assign({ id: this.evento.id, Course: this.evento.Course }, this.registerForm.value);
        this.evento.courseId = 1;
        this.evento.Course = new Course();
        this.eventoService.putEvento(this.evento)
        .subscribe(
          (novoEvento: Evento) => {
            console.log(novoEvento);
            template.hide();
            this.getEventos();
          }, error => {
            console.log(error);
          }
        );
      }
    }
  }

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }
  getEventos(){
    this.eventoService
    .getAllEvento()
    .subscribe(
      response => {
        this.eventos = response;
      }, error => {
        console.log(error);
      }
    );
  }
  getEventoById(){
    var id = Object.assign({ }, this.idForm.value);
    this.eventoService
    .getEventoById(id)
    .subscribe(
      response => {
        this.evento = response;
      }, error => {
        console.log(error)
      }
    )
  }

  editarEvento(evento: Evento, template: any) {
    this.modoSalvar = 'put';
    this.openModal(template);
    this.evento = evento;
    this.registerForm.patchValue(evento);
    
  }

  novoEvento(template: any) {
    this.modoSalvar = 'post';
    this.openModal(template);
  }

  deleteEvento(evento: Evento){
    this.eventoService
    .deleteEvento(evento.id)
    .subscribe(
      () => {
        this.getEventos();
      }, error => {
        console.log(error);
      }
    );  
  }

  getById(id: String){  
    if (id == '') return;  

    this.eventoService
    .getEventoById(Number(id))
    .subscribe(      
      response => {   
        if (response == null) return;

        if (response.id != Number(id)) {
          return;          
        } 
        this.eventoId = response;
        
      }, error => {
        console.log(error);
      }      
    );
  }

  getByCourseId(id: String){
    console.log(Number(id));
    this.eventoService
    .getByCourseId(Number(id))
    .subscribe(
      response => {
        this.eventos = response;      
      }, error => {
        console.log(error);
      }
    )
  }



}
