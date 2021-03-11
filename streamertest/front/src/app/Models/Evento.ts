import { Course } from "./Course";

export class Evento {
    
    
    cosntructor (){
    }

    id: number=0;
    name: string='';
    image: string='';
    why: string='';
    what: string='';
    whatWillWeDo: string='';
    courseId: number=0;
    Course: Course = new Course();
}
