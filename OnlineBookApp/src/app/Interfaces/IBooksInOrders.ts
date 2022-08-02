export interface IBooksInOrders{
    orderId:number,
    bookId:string,
    bookName:string,
    authorName:string,
    cost:number,
    emailId:string,
    orderQuantity:number,
    orderStatus:string,
    orderDate:Date,
    estimatedDelivery:Date
}