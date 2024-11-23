import React, { useCallback, useEffect, useState } from 'react';
import { Ticket } from '../types/Ticket';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import TicketCard from './TicketCard';

const TicketsList = () => {

    const [tickets, setTickets] = useState<Ticket[]>();
    const [isLoading, setIsLoading] = useState(false);
    const [pageNumber, setPageNumber] = useState(1);
    const [ticketsCount, setTicketsCount] = useState(0);

    const dataFetch = useCallback(async () => {
        setIsLoading(true);
        const data = await (
            await fetch(`/tickets?pageNumber=${pageNumber-1}`, {
                headers: { 'Content-Type': 'application/json' },
                credentials: 'include'
            })
        ).json();

        setIsLoading(false);
        setTickets(data.payload);
        setTicketsCount(data.count);
    }, [pageNumber]);

    const handleClick = async (id: number) => {
        const response = await fetch(`/tickets?id=${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' }
        });
        if (response.ok) {
            dataFetch();
        }
    };

    const deleteClick = async (id: number) => {
        const response = await fetch(`/tickets?id=${id}`, {
            method: 'Delete',
            headers: { 'Content-Type': 'application/json' }
        });
        if (response.ok) {
            dataFetch();
        }
    };

    useEffect(() => {
        // fetch data
        dataFetch();
    }, [dataFetch, setPageNumber]);

    const handleNextClick = useCallback(() => {
        setPageNumber(pageNumber + 1);
        dataFetch();
    }, [pageNumber, dataFetch]);

    const handlePrevClick = useCallback(() => {
        setPageNumber(pageNumber - 1);
        dataFetch();
    }, [pageNumber, dataFetch]);
    
    const disableNext = () => {
        if(ticketsCount < 5) return true;
        if(ticketsCount % 5 === 0 )
            return (pageNumber === ticketsCount / 5);
        if(ticketsCount % 5 > 0)
            return (pageNumber === (ticketsCount % 5 + 2));
    };

    if (isLoading)
        return (<FontAwesomeIcon icon={faSpinner} size='10x' spin />);
    if(ticketsCount === 0)
    {
        return (<>No Tickets Found, Please Add using the button above.</>);
    }
    else
        return (
            <div>
                <div className="album py-5 bg-light">
                    <div className="container">

                        <div className="row">
                            {tickets && tickets?.map((ticket, index) => (
                                <TicketCard ticket={ticket} onHandle={handleClick} onDelete={deleteClick}/>
                            ))}
                        </div>
                    </div>
                    {ticketsCount !== 0 && (
                             <nav aria-label="Page navigation" tabIndex={pageNumber}>
                             <ul className="pagination justify-content-center">
                                 <li className="page-item"><a className={pageNumber === 1 ? "page-link disabled" : "page-link"} onClick={handlePrevClick} href="#">Previous</a></li>
                                 <li className="page-item"><a className={disableNext() ? "page-link disabled" : "page-link" } onClick={handleNextClick} href="#">Next</a></li>
                             </ul>
                         </nav>
                    )}
                </div>
            </div>
        );
};

export default TicketsList;
