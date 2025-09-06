import React, { useState } from 'react';
import { useNavigate } from 'react-router';

import CenteredCard from '~/components/layout/centeredCard';
import { Button } from '~/components/ui/button';
import RoleSelection from '~/components/ui/roleSelection';

const roles: ('STUDENT' | 'LECTURER')[] = ['STUDENT', 'LECTURER'];

const Welcome = () => {
  const navigate = useNavigate();
  const [selectedRole, setSelectedRole] = useState(0);

  const handleRoleSelect = () => {
    selectedRole === 0 ? setSelectedRole(1) : setSelectedRole(0);
  };

  const navigateToSignUp = () => {
    navigate('sign-up');
  };

  return (
    <CenteredCard
      cardTitle='Welcome to EduPortal'
      cardDescription='select your user type to continue'
      footer={
        <div className='w-full space-y-4'>
          <Button className='w-full' onClick={navigateToSignUp}>
            Continue
          </Button>
          <p className='text-sm text-center text-muted-foreground'>
            Already have an account?{' '}
            <a href='sign-in' className='text-primary'>
              Sign in{' '}
            </a>
          </p>
        </div>
      }
    >
      {
        <div className='space-y-4'>
          {roles.map((role) => (
            <RoleSelection
              key={role}
              role={role}
              selectedRole={selectedRole}
              handleClick={handleRoleSelect}
            />
          ))}
        </div>
      }
    </CenteredCard>
  );
};

export default Welcome;
