import { Directive ,TemplateRef,ViewContainerRef,Input} from '@angular/core';

@Directive({
  selector: '[appRating]'
})
export class RatingDirective {

  constructor(private templateRef:TemplateRef<any>,private viewContainer:ViewContainerRef) { }
  @Input() set appRating(value:number){
    if(value==null||value==0){
      this.viewContainer.clear();
    }
    else{
      this.viewContainer.clear();
      for(let i=0;i<value;i++){
        this.viewContainer.createEmbeddedView(this.templateRef);
      }
    }
  }
}
