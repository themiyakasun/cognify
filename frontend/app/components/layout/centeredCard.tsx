import type React from 'react';
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from '../ui/card';

type CenteredCardProps = {
  cardTitle: string;
  cardDescription: string;
  children: React.ReactNode;
  footer: React.ReactNode;
};

const CenteredCard = ({
  cardTitle,
  cardDescription,
  children,
  footer,
}: CenteredCardProps) => {
  return (
    <div className='min-h-screen flex items-center justify-center bg-muted'>
      <Card className='w-full max-w-md shadow-lg'>
        <CardHeader className='text-center'>
          <div className='mx-auto'>
            <img src='images/logo.png' className='w-40 mb-5' />
          </div>
          <CardTitle className='md:text-2xl'>{cardTitle}</CardTitle>
          <CardDescription>{cardDescription}</CardDescription>
        </CardHeader>
        <CardContent>{children}</CardContent>
        <CardFooter>{footer}</CardFooter>
      </Card>
    </div>
  );
};

export default CenteredCard;
