import { Button } from "primereact/button";
import { Card } from "primereact/card";

const books = [
    {
        id:1,
        title:'Lorem Ipsum',
        description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ",
        author:'john smith'
    },
    {
        id:2,
        title:'Lorem Ipsum',
        description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ",
        author:'john smith'
    },
    {
        id:3,
        title:'Lorem Ipsum',
        description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ",
        author:'john smith'
    },
    {
        id:4,
        title:'Lorem Ipsum',
        description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ",
        author:'john smith'
    },
]


const header =(
    <div className="overflow-hidden rounded-2xl top-0">
    <img src="/photos/book.jpg"  />
</div>
);

export default function Home() {


    return (
      <div className="container mx-auto flex flex-col gap-4">
       <h2 className="my-8 text-5 font-bold">BOOKS</h2>

       <div className="grid grid-cols-4 gap-4">
{
    books.map(book=>(
        <Card 
        header={header}
        title={book.title}
        subTitle={book.description}
        key={book.id} className="rounded-2xl "
        pt={{
            content:{className:'p1!'}
        }}
        >
            <div className="flex items-center justify-between">
            <span>
                by {book.author}
            </span>

            <Button
            text
            label="Loan"
            icon='i-tabler-arrow-right'
            iconPos="right"
            />
            </div>
    </Card>
    ))
}
       </div>
      </div>
    )
  }