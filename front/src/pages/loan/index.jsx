import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';

const loans = [
    {
        id:1,
        book:'Lorem Ipsum',
        borrower:'john smith',
        isReturned:true
    },
    {
        id:2,
        book:'Lorem Ipsum',
        borrower:'john smith',
        isReturned:false
    },
    {
        id:3,
        book:'Lorem Ipsum',
        borrower:'john smith',
        isReturned:false
    },
    {
        id:4,
        book:'Lorem Ipsum',
        borrower:'john smith',
        isReturned:true
    },
    
  
]


const actionTemplate = (rowData)=>(
<div>
    <Button
    text
    className={rowData.isReturned ? 'text-green':'text-red'}
    icon={rowData.isReturned ? 'i-tabler-check':'i-tabler-x'}
    tooltip={rowData.isReturned ? 'Mark as unReteurned':'Mark as returned'}
    />
</div>
)



export default function Loan() {


    return (
      <div className="container mx-auto flex flex-col gap-4">
       <h2 className="my-6 text-5 font-bold">LOANs</h2>

       <div >
        <DataTable className='border rounded-2xl overflow-hidden' stripedRows value={loans}>
        <Column field="book" header="Book" />
        <Column field="borrower" header="Borrower" />
        <Column field="isReturned" header="Returned" />
        <Column field="markAsReturned" body={actionTemplate}  />

        </DataTable>
       </div>
      </div>
    )
  }