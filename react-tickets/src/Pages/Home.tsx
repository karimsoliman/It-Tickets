import React from 'react';
import TicketsList from '../Components/TicketsList';

const Home: React.FC = () => {
    return (
        <div>
            <>
                <section className="jumbotron text-center">
                    <div className="container">
                        <h1 className="jumbotron-heading">Tickets</h1>
                    </div>
                </section>
                <div className='text-center'>
                    <TicketsList />
                </div>
            </>

        </div>
    );
};

export default Home;
